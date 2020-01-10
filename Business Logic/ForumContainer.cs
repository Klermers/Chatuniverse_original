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
    public class ForumContainer
    {
        private IForumContainer forumrepository = new Forumrepository(new ForumSQL());
        private PostContainer postContainer = new PostContainer("SQL");
        private UserContainer userContainer = new UserContainer("SQL");
        private string context;
        public List<Forum> Forums
        {
            get;
            private set;
        }

        public ForumContainer(string context)
        {
            if (context == "SQL")
            {
                this.context = context;
                forumrepository = new Forumrepository(new ForumSQL());
                postContainer = new PostContainer(context);
                userContainer = new UserContainer(context);
            }
            else if (context == "MEM")
            {
                this.context = context;
                forumrepository = new Forumrepository(new ForumInMemory());
                postContainer = new PostContainer(context);
                userContainer = new UserContainer(context);
            }
        }

        public void GetAllForums()
        {
            List<ForumDTO> forumsdtos = new List<ForumDTO>();
            List<Forum> forums = new List<Forum>();
            forumsdtos = forumrepository.GetAllForums();
            foreach (var forumdto in forumsdtos)
            {
                Forum forum = new Forum(forumdto, context);
                forums.Add(forum);
            }
            Forums = forums;
        }

        public void GetAllForumsDesc()
        {
            List<ForumDTO> forumsdtos = new List<ForumDTO>();
            List<Forum> forums = new List<Forum>();
            forumsdtos = forumrepository.GetAllForums();
            foreach (var forumdto in forumsdtos)
            {
                Forum forum = new Forum(forumdto, context);
                forums.Add(forum);
            }
            Forums = forums;
        }

        public Forum GetForumById(int id)
        {
            ForumDTO forumdto = new ForumDTO();
            forumdto = forumrepository.GetForumById(id);
            postContainer.GetAllPostsByForumId(forumdto.Id);
            userContainer.GetAllUsersById(forumdto.Id);
            Forum forum = new Forum(forumdto, postContainer.Posts, userContainer.Users, context);
            return forum;
        }


    }
}
