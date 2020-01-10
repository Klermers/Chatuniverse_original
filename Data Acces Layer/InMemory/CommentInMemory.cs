using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.InMemory
{
    public class CommentInMemory : ICommentContext
    {
        private static int id = 1;
        private static List<CommentDTO> commentdata = new List<CommentDTO>();

        public List<CommentDTO> CommentData
        {
            get { return commentdata; }
        }

        public CommentInMemory()
        {

        }

        public void CreateComment(string comment, int postid, int userid)
        {
            CommentDTO forumdto = new CommentDTO("comment");
            id += 1;
            commentdata.Add(forumdto);
        }

        public void DeleteComment(int id)
        {
            commentdata.RemoveAll(commentdto => commentdto.Id == id);
        }

        public List<CommentDTO> GetAllCommentsByPostId(int postid)
        {
            return commentdata;
        }

        public void UpdateComment_Comment(int commentid, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
