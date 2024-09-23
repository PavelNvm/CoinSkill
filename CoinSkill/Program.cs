using CoinSkill.Application.Authentication;
using CoinSkill.Application.Services;
using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.DataAccess;
using CoinSkill.DataAccess.Repositories;
using CoinSkill.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CoinSkillDbContext>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(CoinSkillDbContext)));
});

builder.Services.AddScoped<IUsersService,UsersService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
