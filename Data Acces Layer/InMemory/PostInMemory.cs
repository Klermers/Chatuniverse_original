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
            PostDTO postdto = new PostDTO(id, "test", DateTime.Now);
            PostDTO postdto2 = new PostDTO(id, "test2", DateTime.Now);
            PostDTO postdto3 = new PostDTO(id, "test3", DateTime.Now);
            PostDTO postdto4 = new PostDTO(id, "test4", DateTime.Now);
            PostDTO postdto5 = new PostDTO(id, "test5", DateTime.Now);
            postdata.Add(postdto);
            postdata.Add(postdto2);
            postdata.Add(postdto3);
            postdata.Add(postdto4);
            postdata.Add(postdto5);
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
            throw new NotImplementedException();
        }

        public List<PostDTO> GetAllPostsDesc()
        {
            throw new NotImplementedException();
        }

        public PostDTO GetPostById(int postid)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost_Upvotes(int upvote, int postid)
        {
            throw new NotImplementedException();
        }
    }
}
