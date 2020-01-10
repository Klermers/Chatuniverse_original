using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;
using System.Linq;

namespace Data_Acces_Layer.InMemory
{
    public class ForumInMemory : IForumContext
    {
        private static int id = 5;
        private static List<ForumDTO> forumdata = new List<ForumDTO>();

        public List<ForumDTO> ForumData
        {
            get { return forumdata; }
        }

        public ForumInMemory()
        {
            ForumDTO forumdto = new ForumDTO(1, "test1", "test1");
            ForumDTO forumdto2 = new ForumDTO(2, "test2", "test2");
            ForumDTO forumdto3 = new ForumDTO(3, "test3", "test3");
            ForumDTO forumdto4 = new ForumDTO(4, "test4", "test4");
            forumdata.Add(forumdto);
            forumdata.Add(forumdto2);
            forumdata.Add(forumdto3);
            forumdata.Add(forumdto4);
        }

        public void CreateForum(string name, string description)
        {
            ForumDTO forumdto = new ForumDTO(id, name, description);
            id += 1;
            forumdata.Add(forumdto);
        }

        public void DeleteForum(int id)
        {
            forumdata.RemoveAll(forumdto => forumdto.Id == id);

        }

        public List<ForumDTO> GetAllForums()
        {
            return forumdata;
        }

        public List<ForumDTO> GetAllForumsDesc()
        {
            return forumdata.OrderByDescending(forum => forum.Name).ToList();
        }

        public ForumDTO GetForumById(int id)
        {
            return forumdata.Find(forum => forum.Id == id);

        }

        public void UpdateForum_Description(int id, string description)
        {
            ForumDTO forumdto = ForumData.Where(forum => forum.Id == id).FirstOrDefault();
        }
    }
}
