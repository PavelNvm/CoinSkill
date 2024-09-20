using CoinSkill.Core.Models;

namespace CoinSkill.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> ChangePassword(Guid id, string oldPassword, string newPassword);
        Task<Guid> Create(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetUsers();
        Task<Guid> Update(Guid id, int highestStreak, int attempts, int averageStreak);
    }
}