
using CoinSkill.Core.Models;

namespace CoinSkill.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task<string> Login(string email, string password);
        Task Register(string userName, string email, string password);
        Task<List<User>> GetAllUsers();
    }
}