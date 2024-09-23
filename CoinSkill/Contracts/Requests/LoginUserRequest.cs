using System.ComponentModel.DataAnnotations;

namespace CoinSkill.Api.Contracts.Requests
{
    public record LoginUserRequest(
        [Required] string Password,
        [Required] string Email);
}
