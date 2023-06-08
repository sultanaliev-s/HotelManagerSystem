 
using HotelManagerSystem.API.AuthBL.Data;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL;
using HotelManagerSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagerSystemDb _dbContext;
        private readonly DbSet<User> _set;
        private readonly HotelContext _context;

        public UserRepository(HotelManagerSystemDb dbContext, HotelContext context)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<User>();
            _context = context;

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
        
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateUserBalance(int userId, string newBalance)
        {
            var user = await _context.Users.FindAsync(userId);
            user.CheckingAccount = newBalance;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
