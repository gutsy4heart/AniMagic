using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Rating;

public class CreateRatingDto
{
    public required Guid CartoonId { get; set; }
    public required int Score { get; set; }
    
}
