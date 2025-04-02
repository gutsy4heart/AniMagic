using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Interfaces;

public interface ICartoonRepository : IRepository<Cartoon>
{
    Task<IEnumerable<Cartoon>> GetByGenreAsync(string genre);
    Task<IEnumerable<Cartoon>> GetByTitleAsync(string title);
    Task<IEnumerable<Cartoon>> GetPaginatedAsync(int page, int pageSize);


}
