using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.DataAccess.Entites
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public int HighestStreak { get; set; }
        public int Attempts { get; set; }
        public double AverageStreak { get; set; }
    }
}
