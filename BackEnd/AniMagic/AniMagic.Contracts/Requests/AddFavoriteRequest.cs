using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class AddFavoriteRequest
{
    public Guid CartoonId { get; set; }
}
