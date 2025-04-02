using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Interfaces;

public interface IRatingRepository
{
    Task<double> GetAverageRatingAsync(Guid  cartoonId);
    Task AddRatingAsync(Guid userId, Guid cartoonId, int rating);
    Task UpdateRatingAsync(Guid userId, Guid cartoonId, int rating);
}
