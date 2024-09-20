using System.ComponentModel.DataAnnotations;

namespace CoinSkill.Api.Contracts
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
}
