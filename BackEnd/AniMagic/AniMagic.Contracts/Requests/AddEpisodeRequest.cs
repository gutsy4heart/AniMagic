using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class AddEpisodeRequest
{
    public Guid CartoonId { get; set; }
    public string EpisodeTitle { get; set; }
    public string VideoUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
}
