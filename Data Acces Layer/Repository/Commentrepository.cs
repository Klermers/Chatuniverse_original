using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.Repository
{
    public class Commentrepository : ICommentRepository
    {
        private ICommentContext context;

        public Commentrepository(ICommentContext context)
        {
            this.context = context;
        }

        public void CreateComment(string comment, int postid, int userid)
        {
            this.context.CreateComment(comment, postid, userid);
        }

        public void DeleteComment(int id)
        {
            this.context.DeleteComment(id);
        }

        public void UpdateComment_Comment(int commentid, string comment)
        {
            this.context.UpdateComment_Comment(commentid, comment);
        }

        public List<CommentDTO> GetAllCommentsByPostId(int postid)
        {
            return this.context.GetAllCommentsByPostId(postid);
        }
    }
}
