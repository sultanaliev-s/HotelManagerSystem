
using HotelManagerSystem.API.AuthBL.Data;
using HotelManagerSystem.API.AuthBL.Models;
using HotelManagerSystem.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagerSystemDb _dbContext;
        private readonly DbSet<User> _set;

        public UserRepository(HotelManagerSystemDb dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<User>();

            if (_set == null)
                throw new DException($"Table {nameof(User)} doesn't exist");
        }

        public async Task<bool> UpdateUserEmailConfirmedFlag(string email)
        {
            var user = await GetUserByEmailAsync(email);

            if (user == null)
                return false;

            user.IsEmailConfirmed = true;
            _set.Update(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserEmailAsync(string oldEmail, string newEmail)
        {
            var user = await GetUserByEmailAsync(oldEmail);

            if (user == null)
                return false;

            user.Email = newEmail;
            user.NormalizedEmail = newEmail.ToUpper();
            _set.Update(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _set
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RemoveUserByEmail(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return;

            _set.Remove(user);

            _dbContext.SaveChanges();
        }
    }
}
