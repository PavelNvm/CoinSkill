using CoinSkill.Core.Models;

namespace CoinSkill.Application.Authentication
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
