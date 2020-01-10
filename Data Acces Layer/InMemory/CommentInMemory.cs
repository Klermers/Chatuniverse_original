using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.InMemory
{
    public class CommentInMemory : ICommentContext
    {
        private static int id = 5;
        private static List<CommentDTO> commentdata = new List<CommentDTO>();

        public List<CommentDTO> CommentData
        {
            get { return commentdata; }
        }

        public CommentInMemory()
        {
            CommentDTO commentdto = new CommentDTO("comment1");
            CommentDTO commentdto2 = new CommentDTO("comment2");
            CommentDTO commentdto3 = new CommentDTO("comment3");
            CommentDTO commentdto4 = new CommentDTO("comment4");
            commentdata.Add(commentdto);
            commentdata.Add(commentdto2);
            commentdata.Add(commentdto3);
            commentdata.Add(commentdto4);
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
