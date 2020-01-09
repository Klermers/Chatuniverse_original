using System;
using DTO;

namespace ChatUniverseInterface
{
    public interface IForum
    {
        void CreateForum(string name, string description);

        void DeleteForum(int id);

        void UpdateForum_Description(int id, string description);
    }

}
