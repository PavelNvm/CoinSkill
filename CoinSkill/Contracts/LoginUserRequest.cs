using System.ComponentModel.DataAnnotations;

namespace CoinSkill.Api.Contracts
{
    public record LoginUserRequest(
        [Required] string Password,
        [Required] string Email);
}
