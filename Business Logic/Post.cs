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
        IPost repository = new Postrepository(new PostSQL());

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

        public Post(PostDTO postdto, User user, List<Comment> comments, string context)
        {
            Id = postdto.Id;
            Posttitel = postdto.PostTitel;
            Date = postdto.Date;
            Upvotes = postdto.Upvotes;
            User = user;
            if (context == "SQL")
            {
                repository = new Postrepository(new PostSQL());
            }
            else if (context == "MEM")
            {
                repository = new Postrepository(new PostInMemory());
            }
        }

        public Post(string posttitel, DateTime date, string context)
        {
            Posttitel = posttitel;
            Date = date;
            if (context == "SQL")
            {
                repository = new Postrepository(new PostSQL());
            }
            else if (context == "MEM")
            {
                repository = new Postrepository(new PostInMemory());
            }

        }

        public void CreatePost(int forumid, int userid)
        {
            repository.CreatePost(forumid, Posttitel, userid);
        }

        public void UpdatePost_Upvotes()
        {
            repository.UpdatePost_Upvotes(Upvotes, Id);
        }

        public void DeletePost()
        {
            repository.DeletePost(Id);
        }
    }
}
