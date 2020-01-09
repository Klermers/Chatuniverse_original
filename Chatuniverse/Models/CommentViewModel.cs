using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class CommentViewModel
    {
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
        public UserViewModel User
        {
            get;
            private set;
        }

        public CommentViewModel(Comment comment)
        {
            Id = comment.Id;
            Text = comment.Text;
            Upvotes = comment.Upvotes;
            User = new UserViewModel(comment.User);
        }
    }
}
