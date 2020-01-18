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
        private IForum forumrepository = new Forumrepository(new ForumSQL());

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
        public Forum(string forumtitel, string description)
        {
            ForumTitel = forumtitel;
            Desciption = description;
        }

        public Forum(int id)
        {
            Id = id;
        }

        public Forum(IForumRepository forum)
        {
            forumrepository = forum;
        }

        public Forum(ForumDTO forumdto, List<Post> posts, List<User> users)
        {
            Id = forumdto.Id;
            ForumTitel = forumdto.Name;
            Desciption = forumdto.Description;
            Posts = posts;
            Users = users;
        }

        public string CreateForum()
        {
            if(ForumTitel.Length >= 10 && Desciption.Length > 20)
            {
                forumrepository.CreateForum(ForumTitel, Desciption);
                return "forum is Created";
            }
            else
            {
                return "Titel is lower than 10 or Description is lower than 20";
            }
        }

        public string UpdateForum_Description()
        {
            if(Desciption.Length > 20)
            {
                forumrepository.UpdateForum_Description(Id, Desciption);
                return "Desciption got changed";
            }
            else
            {
                return "Desciption is too short";
            }
        }
    }
}

