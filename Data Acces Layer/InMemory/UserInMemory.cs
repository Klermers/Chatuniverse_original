using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.InMemory
{
    public class UserInMemory : IUserContext
    {


        private static int id = 1;
        private static List<UserDTO> userdata = new List<UserDTO>();

        public List<UserDTO> UserData
        {
            get { return userdata; }
        }

        public UserInMemory()
        {

        }

        public void CreateUser(string username, string password)
        {
            UserDTO forumdto = new UserDTO(username, password, DateTime.Now);
            id += 1;
            userdata.Add(forumdto);
        }

        public List<UserDTO> GetAllUsers()
        {
            return UserData;
        }

        public List<UserDTO> GetAllUsersById(int id)
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

        public UserDTO GetUserByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void JoinForum(int userid, int forumid)
        {
            throw new NotImplementedException();
        }

        public void LeaveForum(int forumid, int userid)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser_Password(int userid, string password)
        {
            throw new NotImplementedException();
        }
    }
}
