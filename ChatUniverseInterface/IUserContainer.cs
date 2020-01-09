using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IUserContainer
    {
        List<UserDTO> GetAllUsersById(int id);

        List<UserDTO> GetAllUsers();

        UserDTO GetUserByUserId(int id);

        UserDTO GetUserByPostId(int postid);

        UserDTO GetUserByCommentId(int commentid);

    }
}
