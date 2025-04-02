using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Interfaces;

public interface IUserRepository: IRepository<User>
{
    Task<User> GetByUsernameAsync(string username);
    Task<User> AuthenticateAsync(string username, string password);
}
