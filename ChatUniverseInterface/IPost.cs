using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IPost
    {
        void CreatePost(int forumid, string titel, int userid);

        void DeletePost(int id);
    }
}
