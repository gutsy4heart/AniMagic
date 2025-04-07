using AniMagic.Contracts.Requests;
using AniMagic.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.Interfaces;

public interface IAdminService
{
    Task<IEnumerable<UserResponse>> GetAllUsersAsync();
    Task<UserResponse?> GetUserByIdAsync(Guid userId);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<bool> UpdateUserRoleAsync(Guid userId, string newRole);

    Task<Guid> AddCartoonAsync(CreateCartoonRequest request);
    Task<bool> UpdateCartoonAsync(Guid cartoonId, UpdateCartoonRequest request);
    Task<bool> DeleteCartoonAsync(Guid cartoonId);

}
