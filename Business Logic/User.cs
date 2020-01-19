using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using DTO;

namespace Business_Logic
{
    public class User
    {
        IUser userrepository;

        public int Id
        {
            get;
            private set;
        }
        public string Username
        {
            get;
            private set;
        }
        public string Password
        {
            get;
            private set;
        }
        public DateTime Date
        {
            get;
            private set;
        }

        public User(UserDTO userdto)
        {
            Id = userdto.Id;
            Username = userdto.Username;
            Password = userdto.Password;
            Date = userdto.CreationDate;
        }

        public User(IUserRepository user)
        {
            userrepository = user;
        }

        public string CreateUser(string username , string password)
        {
            if (Username != null || password.Length < 12)
            {
                return "This username is already taken or your password is shorter than 15 letters.";
            }
            else
            {
                userrepository.CreateUser(username, password);
                return "You made a account with chatuniverse.";
            }
        }

        public string LeaveForum(int forumid, int userid)
        {
            if(Username == null)
            {
                return "You aren't a user so you can'tjoin a forum";
            }
            else
            {
                userrepository.LeaveForum(forumid, userid);
                return "You left the forum";
            }
        }

        public string JoinForum(int forumid, int userid)
        {  
            if(Username != null)
            {
                return "User has already join the forum";
            }
            else
            {
                userrepository.JoinForum(userid, forumid);
                return "User Has joined this forum";
            }
        }

    }

}
