using System.Security.Claims;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.ModelOwner;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class OwnerManager
    {
        private readonly UserManager<User> _userManager;

        public OwnerManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> RegisterOwner(RegisterOwnerRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                return new Response(400, false, "Passwords do not match");
            }
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email,
                CheckingAccount = "",
                IsEmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors.Select(e => e.Description));
                return new Response(400, false, aggregatedErrorMessages);
            }
            var addToRoleRes = await _userManager.AddToRoleAsync(user, "Owner");
            if (!addToRoleRes.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                string aggregatedErrorMessages = string.Join("\n", addToRoleRes.Errors.Select(e => e.Description));
                return new Response(400, false, aggregatedErrorMessages);
            }
            var addToUserRoleRes = await _userManager.AddToRoleAsync(user, "User");
            if (!addToUserRoleRes.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                string aggregatedErrorMessages = string.Join("\n", addToUserRoleRes.Errors.Select(e => e.Description));
                return new Response(400, false, aggregatedErrorMessages);
            }
            return new Response(200, false, "Owner created successfully");
        }

        public async Task<Response> UpdateOwner(UpdateOwnerRequest request)
        {
            var owner = await _userManager.FindByIdAsync(request.Id);

            if (owner == null)
            {
                return new Response(404, false, "Owner not found");
            }

            owner.FullName = request.FullName;
            owner.Email = request.Email;

            var result = await _userManager.UpdateAsync(owner);

            if (!result.Succeeded)
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors
                    .Select(e => e.Description));

                return new Response(400, false, aggregatedErrorMessages);
            }

            return new Response(200, true, "Owner updated successfully");
        }

        public async Task<bool> DeleteOwner(string ownerId)
        {
            var owner = await _userManager.FindByIdAsync(ownerId);

            if (owner == null)
            {
                return false;
            }

            await _userManager.DeleteAsync(owner);

            return true;
        }

        public async Task<List<OwnerViewModel>> GetAllOwners()
        {
            var owners = await _userManager.GetUsersInRoleAsync("Owner");

            var ownerViewModels = owners.Select(owner => new OwnerViewModel
            {
                Id = owner.Id,
                FullName = owner.FullName,
                Email = owner.Email
            }).ToList();

            return ownerViewModels;
        }

        public async Task<OwnerViewModel> GetOwnerById(string ownerId)
        {
            var owner = await _userManager.FindByIdAsync(ownerId);

            if (owner == null)
            {
                return null;
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = owner.Id,
                FullName = owner.FullName,
                Email = owner.Email,
            };

            return ownerViewModel;
        }

        public async Task<OwnerViewModel> GetCurrentOwner(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);

            if (user == null)
            {
                return null;
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return ownerViewModel;
        }
    }
}