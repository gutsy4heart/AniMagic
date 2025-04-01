using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CartoonId { get; set; }
    public Cartoon Cartoon { get; set; }
}
