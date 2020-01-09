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
        private string context;

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

        public Comment(CommentDTO commentdto, User user, string context)
        {
            Id = commentdto.Id;
            Text = commentdto.Text;
            Upvotes = commentdto.Upvotes;
            User = user;
            if (context == "SQL")
            {
                this.context = context;
                commentrepository = new Commentrepository(new CommentSQL());
            }
            else if (context == "MEM")
            {
                this.context = context;
                commentrepository = new Commentrepository(new CommentInMemory());
            }
        }

        public Comment(string text, string context)
        {
            Text = text;
            if (context == "SQL")
            {
                this.context = context;
                commentrepository = new Commentrepository(new CommentSQL());
            }
            else if (context == "MEM")
            {
                this.context = context;
                commentrepository = new Commentrepository(new CommentInMemory());
            }
        }

        public void CreateComment(int postid, int userid)
        {
            commentrepository.CreateComment(Text, postid, User.Id);
        }

        public void UpdateComment_Comment()
        {
            commentrepository.UpdateComment_Comment(Id, Text);
        }

        public void DeleteComment()
        {
            commentrepository.DeleteComment(Id);
        }
    }
}
