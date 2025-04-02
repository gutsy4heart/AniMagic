using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class AddFavoriteDto
{
    public required Guid CartoonId { get; set; }
}
