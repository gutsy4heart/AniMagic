using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public class Favorite
{
    public Guid Id { get; set; }

    // Foreign Keys
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CartoonId { get; set; }
    public Cartoon Cartoon { get; set; }
}
