using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Infrastructure.Helpers;

public static class PaginationHelper
{
    public static IEnumerable<T> Paginate<T>(IEnumerable<T> source, int page, int pageSize)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
