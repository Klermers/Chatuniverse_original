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
        private PostContainer postContainer = new PostContainer(new Postrepository(new PostSQL()),new Commentrepository(new CommentSQL()),new Userrepository(new UserSQL()));
        private UserContainer userContainer = new UserContainer(new Userrepository(new UserSQL()));
        public List<Forum> Forums
        {
            get;
            private set;
        }

        public ForumContainer()
        {

        }

        public ForumContainer(IForumRepository forum, IPostRepository post, IUserRepository user, ICommentRepository comment)
        {
            forumrepository = forum;
            postContainer = new PostContainer(post,comment,user);
            userContainer = new UserContainer(user);
        }

        public void GetAllForums()
        {
            List<ForumDTO> forumsdtos = new List<ForumDTO>();
            List<Forum> forums = new List<Forum>();
            forumsdtos = forumrepository.GetAllForums();
            foreach (var forumdto in forumsdtos)
            {
                Forum forum = new Forum(forumdto);
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
                Forum forum = new Forum(forumdto);
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
            Forum forum = new Forum(forumdto, postContainer.Posts, userContainer.Users);
            return forum;
        }


    }
}
