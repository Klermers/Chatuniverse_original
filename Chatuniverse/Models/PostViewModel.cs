using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class PostViewModel
    {
        public int Id
        {
            get;
            private set;
        }
        public string Posttitel
        {
            get;
            private set;
        }
        public DateTime Date
        {
            get;
            private set;
        }
        public int Upvotes
        {
            get;
            private set;
        }

        public List<CommentViewModel> Comments
        {
            get;
            private set;
        }

        public UserViewModel User
        {
            get;
            private set;
        }

        public PostViewModel()
        {

        }

        public PostViewModel(Post post)
        {
            Id = post.Id;
            Posttitel = post.Posttitel;
            Date = post.Date;
            Upvotes = post.Upvotes;
            User = new UserViewModel(post.User);
            if(post.Comments != null)
            {
                foreach (var comment in post.Comments)
                {
                    CommentViewModel commentViewModel = new CommentViewModel(comment);
                    Comments.Add(commentViewModel);
                }
            }
        }

    }
}
