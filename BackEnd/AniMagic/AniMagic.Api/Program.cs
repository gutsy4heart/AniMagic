using AniMagic.Application.Interfaces;
using AniMagic.Application.Services;
using AniMagic.Domain.Interfaces;
using AniMagic.Infrastructure.Concrete;
using AniMagic.Infrastructure.Data;
using AniMagic.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключение к БД
builder.Services.AddDbContext<AniMagicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("AniMagic.Infrastructure")));


// Регистрация зависимостей
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); // ⬅️ Этого не хватало!
builder.Services.AddSingleton<JwtTokenGenerator>(); // если stateless helper

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация middleware и т.д.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
