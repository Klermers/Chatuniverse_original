using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class ForumPostViewModel
    {
        public ForumViewModel Forum
        {
            get;
            private set;
        }

        public PostViewModel Post
        {
            get;
            private set;
        }

        public ForumPostViewModel(Forum forum, Post post)
        {
            Forum = new ForumViewModel(forum);
            Post = new PostViewModel(post);
        }
    }
}
