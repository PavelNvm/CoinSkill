using CoinSkill.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b=>b.UserName).IsRequired();
            builder.Property(b=>b.Email).IsRequired();
            builder.Property(b=>b.PasswordHash).IsRequired();
            builder.Property(b => b.RegistrationDate).IsRequired();
            builder.Property(b => b.HighestStreak).IsRequired();
            builder.Property(b => b.Attempts).IsRequired();
            builder.Property(b => b.AverageStreak).IsRequired();

        }
    }
}
