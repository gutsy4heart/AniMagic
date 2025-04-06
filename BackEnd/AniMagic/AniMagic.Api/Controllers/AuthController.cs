using AniMagic.Application.Interfaces;
using AniMagic.Contracts.Requests;
using AniMagic.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AniMagic.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="request">User registration request</param>
    /// <returns>Authentication response with JWT token</returns>
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromForm] UserRegisterRequest request)
    {
        var response = await _authService.RegisterAsync(request);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="request">User login request</param>
    /// <returns>Authentication response with JWT token</returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromForm] UserLoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        if (response.Success)
            return Ok(response);

        return Unauthorized(response);
    }

}
