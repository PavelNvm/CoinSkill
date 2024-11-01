using CoinSkill.Application.Authentication;
using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.Core.Models;

namespace CoinSkill.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;


        public UsersService(IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider JwtProvider)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProvider = JwtProvider;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = User.Create(Guid.NewGuid(), userName,  hashedPassword, email, DateOnly.FromDateTime(DateTime.Now), 0, 0, 0);
            await _usersRepository.Create(user);

        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Failed to login");
            }
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
        
        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.GetUsers();
        }

        public async Task<string> GetUserNameById(Guid userId)
        {
            return await _usersRepository.GetById(userId).UserName;
        }
    }
}
