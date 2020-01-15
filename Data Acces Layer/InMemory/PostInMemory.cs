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
        private static int id = 6;
        private List<PostDTO> postdata = new List<PostDTO>();

        public List<PostDTO> PostData
        {
            get { return postdata; }
        }

        public PostInMemory()
        {
            PostDTO postdto = new PostDTO(1, "test", DateTime.Now);
            PostDTO postdto2 = new PostDTO(2, "test2", DateTime.Now);
            PostDTO postdto3 = new PostDTO(3, "test3", DateTime.Now);
            PostDTO postdto4 = new PostDTO(4, "test4", DateTime.Now);
            PostDTO postdto5 = new PostDTO(5, "test5", DateTime.Now);
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
    }
}
