using AniMagic.Domain.Interfaces;
using AniMagic.Infrastructure.Helpers;
using System.Security.Claims;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            AttachUserToContext(context, userRepository, token, jwtTokenGenerator);
        }

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserRepository userRepository, string token, JwtTokenGenerator jwtTokenGenerator)
    {
        try
        {
            var secretKey = _configuration["Jwt:SecretKey"];
            var principal = jwtTokenGenerator.ValidateToken(token, secretKey);

            if (principal != null)
            {
                var userId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
                var user = userRepository.GetByIdAsync(userId).Result;

                if (user != null)
                {
                    var identity = new ClaimsIdentity(principal.Claims, "jwt");
                    context.User = new ClaimsPrincipal(identity);
                }
            }
        }
        catch
        {
            // Если ошибка, просто не добавляем пользователя
        }
    }
}
