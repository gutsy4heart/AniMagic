using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class RateCartoonRequest
{
    public Guid CartoonId { get; set; }
    public int Rating { get; set; }  
}
