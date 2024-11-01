using CoinSkill.Application.Authentication;
using CoinSkill.Application.Services;
using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.DataAccess;
using CoinSkill.DataAccess.Repositories;
using CoinSkill.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Tests.Coinskill.Application.Tests
{
    
    public class UserServiceTests
    {
        private readonly IUsersService _userService;
        public UserServiceTests()
        {

            //SUT
            var contextOptions = new DbContextOptionsBuilder<CoinSkillDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new CoinSkillDbContext(contextOptions);
            IOptions<JwtOptions> jwtOptions = Options.Create<JwtOptions>(new JwtOptions() { SecretKey = "asdasd", ExpiresHours = 6 });


            _userService = new UsersService(new UsersRepository(context), new PasswordHasher(), new JwtProvider(jwtOptions));
        }

        [Fact]
        public void UsersService_Register_ReturnString()
        {
            //Arrange
            string userName = "user";
            string email = "user";
            string password = "user";
            //Act

            _userService.Register(userName, email, password);
            var token = _userService.Login(email, password);


            //Assert

            token.Should().NotBeNull();


        }
    }
}
