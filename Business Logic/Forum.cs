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

        public void CreateForum()
        {
            forumrepository.CreateForum(ForumTitel, Desciption);
        }

        public void UpdateForum_Description()
        {
            forumrepository.UpdateForum_Description(Id, Desciption);
        }

        public void DeleteForum()
        {
            forumrepository.DeleteForum(Id);
        }

        public bool IsUserInForum(int id)
        {
            if(Users != null)
            {
                foreach (var user in Users)
                {
                    if (user.Id == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

