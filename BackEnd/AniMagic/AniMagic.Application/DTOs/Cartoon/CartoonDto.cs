using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class CartoonDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public List<string> Episodes { get; set; } = new();
    public string VideoPath { get; set; }
}
