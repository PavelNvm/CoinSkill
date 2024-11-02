using CoinSkill.Api.Contracts.Requests;
using CoinSkill.Api.Contracts.Responses;
using CoinSkill.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoinSkill.Api.Endpoints
{
    public static class CoinFlipEndpoints
    {
        public static IEndpointRouteBuilder MapCoinFlipEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("flipMultipleCoins", FlipMultipleCoins)
                .RequireAuthorization();
            app.MapGet("getLeaderboard", GetLeaderboard).AllowAnonymous();
            


            return app;
        }

        private static async Task<IResult> FlipMultipleCoins(             
            ICoinFlipService coinFlipService,
            HttpContext context)
        {
            Guid userId;
            Guid.TryParse(context.User.FindFirst("userId")?.Value.ToString(), out userId);
            var result = await coinFlipService.FlipMultipleCoins(userId);

            return Results.Ok(new CoinFlipResponse(result.Item1.Streak,result.Item2));
        }

        private static async Task<IResult> GetLeaderboard(
            ICoinFlipService coinFlipService,
            IUsersService usersService,
            int amount = 10
            )
        {
            var Leaderboard = await coinFlipService.GetLeaderboard(amount);
            int i = 0;
            IEnumerable<CoinFLipLeaderboardResponse> result = Leaderboard.Select(c => new CoinFLipLeaderboardResponse(++i,c.Streak,c.UserId, usersService.GetUserNameById(c.UserId).Result.UserName, c.Date) ).ToList();
            return Results.Ok(result);
        }

    }
}
