using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class ForumViewModel
    {
        public int Id
        {
            get;
            set;
        }
        public string ForumTitel
        {
            get;
            set;
        }
        public string Desciption
        {
            get;
            set;
        }
        public List<UserViewModel> Users
        {
            get;
            set;
        }
        public List<PostViewModel> Posts
        {
            get;
            set;
        }

        public ForumViewModel()
        {

        }
        public ForumViewModel(Forum forum)
        {
            Id = forum.Id;
            ForumTitel = forum.ForumTitel;
            Desciption = forum.Desciption;
            if (forum.Users != null)
            {
                List<UserViewModel> users = new List<UserViewModel>();
                foreach (var user in forum.Users)
                {
                    UserViewModel userViewModel = new UserViewModel(user);
                    users.Add(userViewModel);
                }
                Users = users;
            }
            if (forum.Posts != null)
            {
                List<PostViewModel> posts = new List<PostViewModel>();
                foreach (var post in forum.Posts)
                {
                    PostViewModel postViewModel = new PostViewModel(post);
                    posts.Add(postViewModel);
                }
                Posts = posts;
            }
        }
    }
}
