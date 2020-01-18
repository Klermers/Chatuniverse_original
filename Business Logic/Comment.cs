using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.Repository;
using DTO;
using Data_Acces_Layer.InMemory;

namespace Business_Logic
{
    public class Comment
    {
        private ICommentRepository commentrepository;

        public int Id
        {
            get;
            private set;
        }
        public string Text
        {
            get;
            private set;
        }
        public int Upvotes
        {
            get;
            private set;
        }
        public User User
        {
            get;
            private set;
        }

        public Comment(CommentDTO commentdto, User user)
        {
            Id = commentdto.Id;
            Text = commentdto.Text;
            Upvotes = commentdto.Upvotes;
            User = user;
        }

        public Comment(IConnectionString conn)
        {
            commentrepository = new Commentrepository(new CommentSQL(conn));
        }

        public string CreateComment(int postid, int userid, string text)
        {
            if(text.Length < 20)
            {
                return "You need a minimum of 20 letters";
            }
            else
            {
                commentrepository.CreateComment(text, postid, userid);
                return "Comment is created ";
            }
        }

        public string UpdateComment_Text(int id, string text)
        {
            if (text.Length < 20)
            {
                return "You need a minimum of 20 letters";
            }
            else
            {
                commentrepository.UpdateComment_Comment(id, text);
                return "Comment is Changed ";
            }
        }

        public void DeleteComment()
        {
            commentrepository.DeleteComment(Id);
        }
    }
}
