using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class CreateEpisodeDto
{
    public Guid CartoonId { get; set; } 
    public string Title { get; set; } 
    public string VideoPath { get; set; } 
    public DateTime ReleaseDate { get; set; } 
    public int EpisodeNumber { get; set; } 
}
