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
    public class CoinFlipConfiguration: IEntityTypeConfiguration<CoinFlipEntity>
    {
        public void Configure(EntityTypeBuilder<CoinFlipEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.Date).IsRequired();
            builder.Property(x=>x.Streak).IsRequired();
        }
    }
}
