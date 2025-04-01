using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public class Episode
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int EpisodeNumber { get; set; }
    public string VideoPath { get; set; } = string.Empty;

    // Foreign Key
    public Guid CartoonId { get; set; }
    public Cartoon Cartoon { get; set; }
}
