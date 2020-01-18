using System;
using System.Collections.Generic;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using DTO;
using ChatUniverseInterface;

namespace Business_Logic
{
    public class Forum
    {
        private IForum forumrepository;

        public int Id
        {
            get;
            private set;
        }
        public string ForumTitel
        {
            get;
            private set;
        }
        public string Desciption
        {
            get;
            private set;
        }
        public List<User> Users
        {
            get;
            private set;
        }
        public List<Post> Posts
        {
            get;
            private set;
        }

        public Forum(ForumDTO forumdto)
        {
            Id = forumdto.Id;
            ForumTitel = forumdto.Name;
            Desciption = forumdto.Description;
        }

        public Forum(IConnectionString conn)
        {
            forumrepository = new Forumrepository(new ForumSQL(conn));
        }

        public Forum(ForumDTO forumdto, List<Post> posts, List<User> users)
        {
            Id = forumdto.Id;
            ForumTitel = forumdto.Name;
            Desciption = forumdto.Description;
            Posts = posts;
            Users = users;
        }

        public string CreateForum(string forumtitel, string description)
        {
            if(forumtitel.Length >= 10 && forumtitel.Length > 20)
            {
                forumrepository.CreateForum(forumtitel, forumtitel);
                return "forum is Created";
            }
            else
            {
                return "Titel is lower than 10 or Description is lower than 20";
            }
        }

        public string UpdateForum_Description(int id, string description)
        {
            if(description.Length > 20)
            {
                forumrepository.UpdateForum_Description(id,description);
                return "Desciption got changed";
            }
            else
            {
                return "Desciption is too short";
            }
        }
    }
}

