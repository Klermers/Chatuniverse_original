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

        public List<UserDTO> PostData
        {
            get { return userdata; }
        }

        public UserInMemory()
        {
            UserDTO userdto = new UserDTO(id, "username", "password", DateTime.Now);
            userdata.Add(userdto);
        }

        public void CreateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsersById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByCommentId(int commentid)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByPostId(int postid)
        {
            throw new NotImplementedException();
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
