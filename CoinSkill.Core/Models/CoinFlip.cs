using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Core.Models
{
    public class CoinFlip
    {
        private CoinFlip(Guid id,Guid userId, DateOnly date, int streak )
        {
            Id = id;
            UserId = userId;
            Date = date;
            Streak = streak;
        }
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly Date { get; }
        public int Streak { get; }

        public static CoinFlip Create(Guid id, Guid userId, DateOnly date, int streak)
        {
            return new CoinFlip(id, userId, date, streak);
        }


    }
}
