using CoinSkill.DataAccess.Entites;

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
        public static User Create(UserEntity userEntity)
        {

        }
    }
}
