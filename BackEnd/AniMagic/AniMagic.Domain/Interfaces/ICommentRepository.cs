using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByCartoonIdAsync(Guid cartoonId);
    Task AddCommentAsync(Comment comment);
    Task UpdateCommentAsync(Comment comment);
    Task DeleteCommentAsync(Guid commentId, Guid userId);
}
