using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AniMagic.Domain.Models;

public class Cartoon
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string FilePath { get; set; } // Path to video file
    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
