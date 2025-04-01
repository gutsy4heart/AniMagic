using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public class Rating
{
    public Guid Id { get; set; }
    public int Score { get; set; } // 1 - 10

    // Foreign Keys
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CartoonId { get; set; }
    public Cartoon Cartoon { get; set; }
}
