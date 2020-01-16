using System;
using System.Collections.Generic;
using System.Text;
using ChatUniverseInterface;
using DTO;

namespace Data_Acces_Layer.Repository
{
    public class Userrepository : IUserRepository
    {
        private IUserContext context;

        public Userrepository(IUserContext context)
        {
            this.context = context;
        }
        public void CreateUser(string username, string password)
        {
            this.context.CreateUser(username, password);
        }

        public void LeaveForum(int forumid, int userid)
        {
            this.context.LeaveForum(forumid, userid);
        }

        public void JoinForum(int userid, int forumid)
        {
            this.context.JoinForum(userid, forumid);
        }

        public List<UserDTO> GetAllUsersByForumId(int forumid)
        {
            return this.context.GetAllUsersByForumId(forumid);
        }

        public UserDTO GetUserByForumId(int forumid, int userid)
        {
            return this.context.GetUserByForumId(forumid, userid);
        }

        public UserDTO GetUserByPostId(int postid)
        {
            return this.context.GetUserByPostId(postid);
        }

        public UserDTO GetUserByCommentId(int commentid)
        {
            return this.context.GetUserByCommentId(commentid);
        }

        public UserDTO GetUserByUsernamePassword(string username, string password)
        {
            return this.context.GetUserByUsernamePassword(username,password);
        }

        public UserDTO GetUserById(int id)
        {
            return this.context.GetUserById(id);
        }
    }
}
