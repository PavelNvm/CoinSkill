﻿using CoinSkill.Api.Contracts;

namespace CoinSkill.Api.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);



            return app;
        }
        private static async Task<IResult> Register(RegisterUserRequest user, UserService userService)
        {


            await userService.Register(user.UserName, user.Email, user.Password);
            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UserService userService)
        {
            var token = await userService.Login(request.Email, request.Password);
            return Results.Ok(token);
        }
    }
}
