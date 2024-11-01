using CoinSkill.Api.Contracts.Requests;
using CoinSkill.Application.Services;
using CoinSkill.Core.Interfaces.Services;

namespace CoinSkill.Api.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);
            //app.MapGet("")


            return app;
        }
        private static async Task<IResult> Register(RegisterUserRequest user, IUsersService userService)
        {
            await userService.Register(user.UserName, user.Email, user.Password);
            return Results.Ok();
        }

        private static async Task<IResult> Login(
            LoginUserRequest request, 
            IUsersService userService,
            HttpContext context)
        {
            var token = await userService.Login(request.Email, request.Password);

            context.Response.Cookies.Append("cookies", token);
            return Results.Ok();
        }
    }

}
