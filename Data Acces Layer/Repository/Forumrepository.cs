using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.Repository
{
    public class Forumrepository : IForumRepository
    {
        private IForumContext context;

        public Forumrepository(IForumContext context)
        {
            this.context = context;
        }

        public void CreateForum(string name, string description)
        {
            this.context.CreateForum(name, description);
        }

        public void UpdateForum_Description(int id, string description)
        {
            this.context.UpdateForum_Description(id, description);
        }

        public List<ForumDTO> GetAllForums()
        {
            return this.context.GetAllForums();
        }

        public List<ForumDTO> GetAllForumsDesc()
        {
            return this.context.GetAllForumsDesc();
        }

        public ForumDTO GetForumById(int id)
        {
            return this.context.GetForumById(id);
        }
    }
}
