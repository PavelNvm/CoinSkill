using CoinSkill.Application.Services;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.DataAccess;
using CoinSkill.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Tests.Coinskill.Application.Tests
{
    public class CoinFlipServiceTests
    {
        private readonly ICoinFlipService _coinFlipService;
        public CoinFlipServiceTests()
        {
            //SUT
            var contextOptions = new DbContextOptionsBuilder<CoinSkillDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new CoinSkillDbContext(contextOptions);
            _coinFlipService = new CoinFlipService(new UsersRepository(context), new CoinFlipRepository(context));

        }

        //[Fact]
        //public void 



    }
}
