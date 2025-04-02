using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class FavoriteDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CartoonId { get; set; }
    public string CartoonTitle { get; set; }
}
