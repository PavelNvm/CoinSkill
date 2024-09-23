using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Models;
using CoinSkill.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;


namespace CoinSkill.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CoinSkillDbContext _context;

        public UsersRepository(CoinSkillDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities.Select(b => User.Create(b.Id, b.UserName, b.PasswordHash, b.Email, b.RegistrationDate, b.HighestStreak, b.Attempts, b.AverageStreak)).ToList();
            return users;
        }
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstAsync(u => u.Email == email);

            return User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email, userEntity.RegistrationDate, userEntity.HighestStreak, userEntity.Attempts, userEntity.AverageStreak);

        }
        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                HighestStreak = user.HighestStreak,
                Attempts = user.Attempts,
                AverageStreak = user.AverageStreak,
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, int highestStreak, int attempts, int averageStreak)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.HighestStreak, u => highestStreak)
                    .SetProperty(u => u.Attempts, u => attempts)
                    .SetProperty(u => u.AverageStreak, u => averageStreak)
                    );

            var user = await _context.Users.FindAsync(id);
            return id;
        }
        public async Task<Guid> ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.PasswordHash, u => newPassword));
            return id;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
