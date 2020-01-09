using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IForumContainer
    {
        List<ForumDTO> GetAllForums();

        List<ForumDTO> GetAllForumsDesc();

        ForumDTO GetForumById(int id);
    }
}
