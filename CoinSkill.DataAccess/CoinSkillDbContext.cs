using CoinSkill.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace CoinSkill.DataAccess
{
    public class CoinSkillDbContext : DbContext
    {
        public CoinSkillDbContext(DbContextOptions<CoinSkillDbContext> options)
            :base (options)
        {
            

        }
        public DbSet<UserEntity> Users { get; set; }


    }
}
