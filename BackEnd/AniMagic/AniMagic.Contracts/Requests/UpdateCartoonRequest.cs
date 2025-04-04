using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class UpdateCartoonRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public string PosterUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
}
