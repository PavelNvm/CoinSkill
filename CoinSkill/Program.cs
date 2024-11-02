using CoinSkill.Api.Endpoints;
using CoinSkill.Api.Extensions;
using CoinSkill.Application.Authentication;
using CoinSkill.Application.Services;
using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.DataAccess;
using CoinSkill.DataAccess.Repositories;
using CoinSkill.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<CoinSkillDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(CoinSkillDbContext)));
});

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));
services.AddScoped<IUsersService, UsersService>();
services.AddScoped<ICoinFlipService, CoinFlipService>();
services.AddScoped<IUsersRepository, UsersRepository>();
services.AddScoped<ICoinFlipRepository, CoinFlipRepository>();
services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IJwtProvider, JwtProvider>();

services.AddApiAuthentication(configuration);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.AddMappedEndpoints();

app.UseHttpsRedirection();


app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();




app.Run();
