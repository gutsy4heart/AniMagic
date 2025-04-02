using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class CreateCartoonDto
{
    public required string Title { get; set; }
    public string Description { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public List<string> Episodes { get; set; } = new();
}
