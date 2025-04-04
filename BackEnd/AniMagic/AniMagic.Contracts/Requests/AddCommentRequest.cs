using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class AddCommentRequest
{
    public Guid CartoonId { get; set; }
    public string CommentText { get; set; }
}
