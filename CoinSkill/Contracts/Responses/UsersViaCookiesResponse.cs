using System;

namespace CoinSkill.Api.Contracts.Responses
{
    public record UsersViaCookiesResponse(
        Guid Id,
        string Username,
        string Email,
        DateOnly Registrationdate,
        int Higheststreak,
        int Attempts,
        double Averagestreak);
}
