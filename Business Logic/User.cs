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

        public User(UserDTO userdto, string context)
        {
            Id = userdto.Id;
            Username = userdto.Username;
            Password = userdto.Password;
            Date = userdto.CreationDate;
        }

        public User(int userid, string context)
        {
            Id = userid;
            if (context == "SQL")
            {
                userrepository = new Userrepository(new UserSQL());
            }
            else if (context == "MEM")
            {
                userrepository = new Userrepository(new UserInMemory());
            }
        }

        public User(string username, string password, DateTime datetime, string context)
        {
            Username = username;
            Password = password;
            Date = datetime;
            if (context == "SQL")
            {
                userrepository = new Userrepository(new UserSQL());
            }
            else if (context == "MEM")
            {
                userrepository = new Userrepository(new UserInMemory());
            }
        }

        public void CreateUser()
        {
            userrepository.CreateUser(Username, Password);
        }

        public void LeaveForumm(int forumid)
        {
            userrepository.LeaveForum(forumid, Id);
        }

        public void JoinForum(int forumid)
        {
            userrepository.JoinForum(Id, forumid);
        }

        public void UpdateUser_Password(string password)
        {
            userrepository.UpdateUser_Password(Id, password);
        }
    }

}
