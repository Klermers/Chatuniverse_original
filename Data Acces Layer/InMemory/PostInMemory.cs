using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;
using System.Linq;

namespace Data_Acces_Layer.InMemory
{
    public class PostInMemory : IPostContext
    {
        private static int id = 1;
        private static List<PostDTO> postdata = new List<PostDTO>();

        public List<PostDTO> PostData
        {
            get { return postdata; }
        }

        public PostInMemory()
        {

        }

        public void CreatePost(int forumid, string titel, int userid)
        {
            PostDTO postdto = new PostDTO(id, titel, DateTime.Now);
            id += 1;
            postdata.Add(postdto);
        }

        public void DeletePost(int id)
        {
            postdata.RemoveAll(postdto => postdto.Id == id);
        }

        public List<PostDTO> GetAllPosts()
        {
            return PostData;
        }

        public List<PostDTO> GetAllPostsByForumId(int forumid)
        {
            return PostData;
        }

        public List<PostDTO> GetAllPostsByForumIdDesc(int forumid)
        {
            return PostData.OrderByDescending(post => post.PostTitel).ToList();
        }

        public List<PostDTO> GetAllPostsDesc()
        {
            return PostData.OrderByDescending(post => post.PostTitel).ToList();
        }

        public PostDTO GetPostById(int postid)
        {
            return PostData.Find(post => post.Id == id);
        }

        public void UpdatePost_Upvotes(int upvote, int postid)
        {
            throw new NotImplementedException();
        }
    }
}
