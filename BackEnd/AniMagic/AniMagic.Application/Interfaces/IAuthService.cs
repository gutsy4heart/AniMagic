using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniMagic.Contracts.Requests;
using AniMagic.Contracts.Responses;
namespace AniMagic.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(UserRegisterRequest request);
    Task<AuthResponse> LoginAsync(UserLoginRequest request);
    
}
