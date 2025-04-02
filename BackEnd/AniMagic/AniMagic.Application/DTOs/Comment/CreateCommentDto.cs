using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Comment;

public class CreateCommentDto
{
    public required Guid CartoonId { get; set; }
    public required string Content { get; set; }
}
