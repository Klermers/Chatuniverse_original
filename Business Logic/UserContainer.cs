using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Data_Acces_Layer.Repository;
using Data_Acces_Layer.SQL;
using Data_Acces_Layer.InMemory;
using ChatUniverseInterface;

namespace Business_Logic
{
    public class UserContainer
    {
        private IUserContainer userRepositoryContainer = new Userrepository(new UserSQL());
        private string context;
        public List<User> Users
        {
            get;
            private set;
        }

        public UserContainer(string context)
        {
            if (context == "SQL")
            {
                this.context = context;
                userRepositoryContainer = new Userrepository(new UserSQL());
            }
            else if (context == "MEM")
            {
                this.context = context;
                userRepositoryContainer = new Userrepository(new UserInMemory());
            }
        }

        public void GetAllUsersById(int forumid)
        {
            List<User> users = new List<User>();
            List<UserDTO> userdtos = new List<UserDTO>();
            userdtos = userRepositoryContainer.GetAllUsersById(forumid);
            foreach (var userdto in userdtos)
            {
                User user = new User(userdto, context);
                users.Add(user);

            }

            Users = users;
        }

        public void GetAllUsers()
        {
            List<User> users = new List<User>();
            List<UserDTO> userdtos = new List<UserDTO>();
            userdtos = userRepositoryContainer.GetAllUsers();
            foreach (var userdto in userdtos)
            {
                User user = new User(userdto, context);
                users.Add(user);

            }

            Users = users;
        }

        public User GetUserById(int id)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByUserId(id);
            User user = new User(userdto, context);
            return user;
        }

        public User GetUserByPostId(int postid)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByPostId(postid);
            User user = new User(userdto, context);
            return user;
        }

        public User GetUserByCommentId(int commentid)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByCommentId(commentid);
            User user = new User(userdto, context);
            return user;
        }

    }
}
