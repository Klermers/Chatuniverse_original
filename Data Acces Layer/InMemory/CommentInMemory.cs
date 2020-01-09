using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.InMemory
{
    public class CommentInMemory : ICommentContext
    {
        public void CreateComment(string comment, int postid)
        {
            throw new NotImplementedException();
        }

        public void CreateComment(string comment, int postid, int userid)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentDTO> GetAllCommentsByPostId(int postid)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment_Comment(int commentid, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
