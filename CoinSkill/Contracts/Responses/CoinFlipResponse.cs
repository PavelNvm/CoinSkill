namespace CoinSkill.Api.Contracts.Responses
{
    
    public record CoinFlipResponse(
        int Streak,
        bool NewFlip);// В случае если бросок сегодня уже был произведен возвращается сегодняшний
}
