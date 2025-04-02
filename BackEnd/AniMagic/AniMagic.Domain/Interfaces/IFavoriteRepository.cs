using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Interfaces;

public interface IFavoriteRepository 
{
    Task<IEnumerable<Cartoon>> GetUserFavoritesAsync(Guid userId);
    Task AddToFavoritesAsync(Guid userId, Guid cartoonId);
    Task DeleteFromFavoritesAsync(Guid userId, Guid cartoonId);
}
