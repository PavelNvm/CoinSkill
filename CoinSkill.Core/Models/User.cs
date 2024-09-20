using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Core.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email, DateOnly registrationDate,int highestStreak, int attempts, double averageStreak)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            HighestStreak = 0;
            Attempts = 0;
            AverageStreak = 0;
            RegistrationDate = registrationDate;
            HighestStreak = highestStreak;
            Attempts = attempts;
            AverageStreak = averageStreak;
            //DateOnly.FromDateTime(DateTime.Now)
        }
        public Guid Id { get; }
        public string UserName { get; }
        public string PasswordHash { get; }
        public string Email { get; }
        public DateOnly RegistrationDate { get; }
        public int HighestStreak { get; }
        public int Attempts { get; }
        public double AverageStreak { get; }


        public static User Create(Guid id, string userName, string passwordHash, string email, DateOnly registrationDate, int highestStreak, int attempts, double averageStreak)
        {
            //Validation
            //if(string.IsNullOrEmpty(userName))

            return new User(id, userName, passwordHash, email, registrationDate, highestStreak, attempts, averageStreak);
        }
    }
}
