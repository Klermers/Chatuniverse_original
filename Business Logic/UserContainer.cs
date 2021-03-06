﻿using System;
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
        private IUserContainer userRepositoryContainer;
        public List<User> Users
        {
            get;
            private set;
        }

        public UserContainer(IConnectionString conn)
        {
            userRepositoryContainer = new Userrepository(new UserSQL(conn));
        }

        public void GetAllUsersByForumId(int forumid)
        {
            List<User> users = new List<User>();
            List<UserDTO> userdtos = new List<UserDTO>();
            userdtos = userRepositoryContainer.GetAllUsersByForumId(forumid);
            foreach (var userdto in userdtos)
            {
                User user = new User(userdto);
                users.Add(user);

            }
            Users = users;
        }

        public User GetUserByPostId(int postid)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByPostId(postid);
            User user = new User(userdto);
            return user;
        }

        public User GetUserByCommentId(int commentid)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByCommentId(commentid);
            User user = new User(userdto);
            return user;
        }

        public User GetUserByUsernamePassword(string username,string password)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByUsernamePassword(username,password);
            User user = new User(userdto);
            return user;
        }

        public User GetUserById(int id)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserById(id);
            User user = new User(userdto);
            return user;
        }

        public User GetUserByForumId(int forumid, int userid)
        {
            UserDTO userdto = new UserDTO();
            userdto = userRepositoryContainer.GetUserByForumId(forumid,userid);
            User user = new User(userdto);
            return user;
        }

    }
}
