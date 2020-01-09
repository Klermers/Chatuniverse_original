using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface ICommentContainer
    {
        List<CommentDTO> GetAllCommentsByPostId(int postid);
    }
}
