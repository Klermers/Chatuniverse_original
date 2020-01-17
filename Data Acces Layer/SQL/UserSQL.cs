using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using MySql.Data.MySqlClient;
using ChatUniverseInterface;

namespace Data_Acces_Layer.SQL
{
    public class UserSQL : IUserContext
    {
        MySqlConnection conn;
        string connectionstring = "Server=studmysql01.fhict.local;Uid=dbi393712;Database=dbi393712;Pwd=catlover1214;";

        public void CreateUser(string username, string password)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "INSERT INTO User(Username,Password,Date) VALUES(@Username,@Password,@Date)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UserDTO> GetAllUsersByForumId(int forumid)
        {

            List<UserDTO> userdtos = new List<UserDTO>();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user INNER JOIN forum_user ON user.Id = forum_user.UserId WHERE forum_user.Forumid = @ForumId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ForumId", forumid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            UserDTO userdto = new UserDTO(Id, Username, Password, CreationDate);
                            userdtos.Add(userdto);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                userdtos = null;
            }
            return userdtos;
        }

        public UserDTO GetUserByForumId(int forumid, int userid)
        {
            UserDTO userdto = new UserDTO();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user INNER JOIN forum_user ON user.Id = @Userid WHERE forum_user.ForumId = @ForumId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ForumId", forumid);
                        cmd.Parameters.AddWithValue("@Userid", userid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            userdto = new UserDTO(Id, Username, Password, CreationDate); ;
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                userdto = null;
            }
            return userdto;
        }

        public UserDTO GetUserByCommentId(int commentid)
        {
            UserDTO userdto = new UserDTO();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user INNER JOIN comment ON user.Id = comment.userid WHERE comment.id = @Commentid ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Commentid", commentid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            userdto = new UserDTO(Id, Username, Password, CreationDate);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                userdto = null;
            }
            return userdto;
        }

        public UserDTO GetUserByPostId(int postid)
        {
            UserDTO userdto = new UserDTO();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user INNER JOIN post ON user.Id = @postid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postid", postid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            userdto = new UserDTO(Id, Username, Password, CreationDate);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                userdto = null;
            }
            return userdto;
        }

        public void JoinForum(int userid, int forumid)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "INSERT INTO forum_user(ForumId,UserId) VALUES(@ForumId,@UserId)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ForumId", forumid);
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LeaveForum(int forumid, int userid)
        {
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "DELETE FROM forum_user WHERE ForumId = @ForumId AND UserId = @UserId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ForumId", forumid);
                        cmd.Parameters.AddWithValue("@UserId", userid);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(NullReferenceException)
            {

            }
        }

        public UserDTO GetUserByUsernamePassword(string username, string password)
        {
            UserDTO userdto = new UserDTO();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user WHERE user.Username = @Username AND user.Password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            userdto = new UserDTO(Id, Username, Password, CreationDate);
                        }

                    }
                }
            }
            catch (ArgumentNullException)
            {
                userdto = null;
            }
            return userdto;
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO userdto = new UserDTO();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM user WHERE user.id = @userid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", id);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);
                            DateTime CreationDate = reader.GetDateTime(3);
                            userdto = new UserDTO(Id, Username, Password, CreationDate);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                userdto = null;
            }
            return userdto;
        }
    }
}
