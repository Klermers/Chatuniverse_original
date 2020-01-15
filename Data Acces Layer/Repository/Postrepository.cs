using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.Repository
{
    public class Postrepository : IPostRepository
    {
        private IPostContext context;
        public Postrepository(IPostContext context)
        {
            this.context = context;
        }

        public void CreatePost(int forumid, string titel, int userid)
        {
            this.context.CreatePost(forumid, titel, userid);
        }

        public void DeletePost(int id)
        {
            this.context.DeletePost(id); ;
        }

        public PostDTO GetPostById(int postid)
        {
            return this.context.GetPostById(postid);
        }

        public List<PostDTO> GetAllPosts()
        {
            return this.context.GetAllPosts();
        }

        public List<PostDTO> GetAllPostsDesc()
        {
            return this.context.GetAllPostsDesc();
        }

        public List<PostDTO> GetAllPostsByForumId(int forumid)
        {
            return this.context.GetAllPostsByForumId(forumid);
        }

        public List<PostDTO> GetAllPostsByForumIdDesc(int forumid)
        {
            return this.context.GetAllPostsByForumIdDesc(forumid);
        }
    }
}
