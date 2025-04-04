using AniMagic.Application.Interfaces;
using AniMagic.Contracts.Requests;
using AniMagic.Contracts.Responses;
using AniMagic.Domain.Interfaces;
using AniMagic.Domain.Models;
using AniMagic.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.Services;

public class AuthService : IAuthService
{
    
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, JwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _jwtTokenGenerator = jwtTokenGenerator;
    }


    public async Task<AuthResponse> RegisterAsync(UserRegisterRequest request)
    {
        // Check if the user already exists
        var existingUser = await _userRepository.GetByUsernameAsync(request.UserName);
        if (existingUser != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Username already exists."
            };
        }

        // Create a new user
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.UserName,
            PasswordHash = Hasher.HashPassword(request.Password),
            Role = new Roles("User"), 
            Email = request.Email
        };

        await _userRepository.AddUserAsync(user);

        // Generate a JWT token for the user
        var token = _jwtTokenGenerator.GenerateToken(user, _configuration["Jwt:SecretKey"]);

        return new AuthResponse
        {
            Success = true,
            Message = "Registration successful",
            Token = token
        };
    }

    // User login and JWT generation
    public async Task<AuthResponse> LoginAsync(UserLoginRequest request)
    {
        // Find user by username
        var user = await _userRepository.GetByUsernameAsync(request.UserName);
        if (user == null || !Hasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid username or password."
            };
        }

        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user, _configuration["Jwt:SecretKey"]);

        return new AuthResponse
        {
            Success = true,
            Message = "Login successful",
            Token = token
        };
    }


}
