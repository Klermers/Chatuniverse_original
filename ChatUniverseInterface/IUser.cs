using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace ChatUniverseInterface
{
    public interface IUser
    {
        void CreateUser(string username, string password);

        void LeaveForum(int forumid, int userid);

        void JoinForum(int userid, int forumid);

        void UpdateUser_Password(int userid, string password);

        bool LoginUser(string username, string password);


    }
}
