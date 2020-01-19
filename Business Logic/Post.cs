using System;
using System.Collections.Generic;
using System.Text;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using DTO;
using ChatUniverseInterface;

namespace Business_Logic
{
    public class Post
    {
        IPost postrepository;

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
        public List<Comment> Comments
        {
            get;
            private set;
        }
        public User User
        {
            get;
            private set;
        }

        public Post(PostDTO postdto, User user, List<Comment> comments)
        {
            Id = postdto.Id;
            Posttitel = postdto.PostTitel;
            Date = postdto.Date;
            Upvotes = postdto.Upvotes;
            User = user;
        }

        public Post(IPostRepository post)
        {
            postrepository = post;
        }

        public string CreatePost(int forumid, int userid, string posttitel)
        {
            if(posttitel.Length >= 10)
            {
                postrepository.CreatePost(forumid, posttitel, userid);
                return "Post is Created";
            }
            else
            {
                return "Titel needs a minimum of 10";
            }
        }
        public void DeletePost()
        {
            postrepository.DeletePost(Id);
        }
    }
}
