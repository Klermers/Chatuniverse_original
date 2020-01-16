using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IUserContainer
    {
        List<UserDTO> GetAllUsersByForumId(int forumid);

        UserDTO GetUserByPostId(int postid);

        UserDTO GetUserByCommentId(int commentid);

        UserDTO GetUserByUsernamePassword(string username, string password);

        UserDTO GetUserById(int id);

        UserDTO GetUserByForumId(int forumid, int userid);

    }
}
