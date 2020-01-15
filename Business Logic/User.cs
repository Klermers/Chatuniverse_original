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
        IUser userrepository = new Userrepository(new UserSQL());
        private UserContainer userContainer = new UserContainer(new Userrepository(new UserSQL()));

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

        public User(int userid)
        {
            Id = userid;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(IUserRepository user)
        {
            userrepository = user;
            userContainer = new UserContainer(user);
        }

        public string CreateUser()
        {
            if (userContainer.GetUserByUsername(Username).Username == Username || Password.Length < 12)
            {
                return "This username is already taken or your password is shorter than 15 letters.";
            }
            else
            {
                userrepository.CreateUser(Username, Password);
                return "You made a account with chatuniverse.";
            }
        }

        public string LeaveForumm(int forumid)
        {
            User user = userContainer.GetUserByUsername(Username);
            if(user == null)
            {
                return "You aren't a user so you can''tjoin a forum";
            }
            else
            {
                userrepository.LeaveForum(forumid, Id);
                return "You left the forum";
            }
        }

        public string JoinForum(int forumid)
        {
            if(userContainer.GetUserByForumId(forumid,Id).Id == Id)
            {
                return "User has already join the forum";
            }
            else
            {
                userrepository.JoinForum(Id, forumid);
                return "User Has join this forum";
            }
        }

        public bool LoginUser()
        {
            if(userrepository.LoginUser(Username, Password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
