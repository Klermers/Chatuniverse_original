using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IPostContainer
    {
        List<PostDTO> GetAllPostsByForumId(int forumid);

        List<PostDTO> GetAllPostsByForumIdDesc(int forumid);

        PostDTO GetPostById(int postid);
    }
}
