namespace CoinSkill.Api.Contracts.Responses
{
    public record CoinFLipLeaderboardResponse(
        int Position,
        int Streak,
        Guid UserId,
        string Username,
        DateOnly DateOdRecord
        );
}
