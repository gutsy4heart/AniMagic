using AniMagic.Application.Interfaces;
using AniMagic.Contracts.Requests;
using AniMagic.Contracts.Responses;
using AniMagic.Domain.Interfaces;
using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly ICartoonRepository _cartoonRepository;

    public AdminService(IUserRepository userRepository, ICartoonRepository cartoonRepository)
    {
        _userRepository = userRepository;
        _cartoonRepository = cartoonRepository;
    }
    public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role.ToString()
        });
    }

    public async Task<UserResponse?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return null;

        return new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        await _userRepository.DeleteUserAsync(userId);
        return true;
    }

    public async Task<bool> UpdateUserRoleAsync(Guid userId, string newRole)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        user.Role = Enum.TryParse(newRole, out Roles role) ? role : user.Role;
        await _userRepository.UpdateUserAsync(user);
        return true;
    }

    public async Task<Guid> AddCartoonAsync(CreateCartoonRequest request)
    {
        var cartoon = new Cartoon
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Rating = request.Rating,
            VideoPath = request.VideoPath,
            CreatedAt = DateTime.UtcNow
        };

        await _cartoonRepository.AddAsync(cartoon);
        return cartoon.Id;
    }

    public async Task<bool> UpdateCartoonAsync(Guid cartoonId, UpdateCartoonRequest request)
    {
        var cartoon = await _cartoonRepository.GetByIdAsync(cartoonId);
        if (cartoon == null) return false;

        cartoon.Title = request.Title;
        cartoon.Description = request.Description;
        cartoon.Rating = request.Rating;
        cartoon.VideoPath = request.VideoPath;

        await _cartoonRepository.UpdateAsync(cartoon);
        return true;
    }

    public async Task<bool> DeleteCartoonAsync(Guid cartoonId)
    {
        var cartoon = await _cartoonRepository.GetByIdAsync(cartoonId);
        if (cartoon == null) return false;

        await _cartoonRepository.DeleteAsync(cartoonId);
        return true;
    }
}
