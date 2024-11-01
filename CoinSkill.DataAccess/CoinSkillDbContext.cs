using CoinSkill.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoinSkill.DataAccess
{
    public class CoinSkillDbContext : DbContext
    {
        public CoinSkillDbContext(DbContextOptions<CoinSkillDbContext> options)
            :base (options)
        {
           

            

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CoinFlipEntity> CoinFlips { get; set; }

    }
}
