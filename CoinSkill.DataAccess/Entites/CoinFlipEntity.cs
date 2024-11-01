using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.DataAccess.Entites
{
    public class CoinFlipEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public int Streak { get; set; }
    }
}
