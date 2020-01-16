using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.InMemory
{
    public class UserInMemory : IUserContext
    {


        private static int id = 4;
        private List<UserDTO> userdata = new List<UserDTO>();

        public List<UserDTO> UserData
        {
            get { return userdata; }
        }

        public UserInMemory()
        {
            UserDTO userdto = new UserDTO(1, "username", "password", DateTime.Now);
            UserDTO userdto2 = new UserDTO(2, "username2", "password2", DateTime.Now);
            UserDTO userdto3 = new UserDTO(3, "username3", "password3", DateTime.Now);
            userdata.Add(userdto);
            userdata.Add(userdto2);
            userdata.Add(userdto3);
        }

        public void CreateUser(string username, string password)
        {
            UserDTO forumdto = new UserDTO(username, password, DateTime.Now);
            id += 1;
            userdata.Add(forumdto);
        }

        public List<UserDTO> GetAllUsersByForumId(int id)
        {
            return UserData;
        }

        public UserDTO GetUserByCommentId(int commentid)
        {
            return new UserDTO(100, "customuser", "custompass", DateTime.Now);
        }

        public UserDTO GetUserByPostId(int postid)
        {
            return new UserDTO(100, "customuser", "custompass", DateTime.Now);
        }

        public void JoinForum(int userid, int forumid)
        {
            throw new NotImplementedException();
        }

        public void LeaveForum(int forumid, int userid)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByUsernamePassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByForumId(int forumid, int userid)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
