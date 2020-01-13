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

        public bool LoginUser(string username, string password)
        {
            UserDTO userdto = new UserDTO();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM User WHERE Username = @Username AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch(NullReferenceException)
                    {
                        return false;
                    }

                }
            } 
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> userdtos = new List<UserDTO>();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM user";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserDTO userdto = new UserDTO();
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                        userdtos.Add(userdto);
                    }

                }
            }
            return userdtos;
        }

        public List<UserDTO> GetAllUsersById(int forumid)
        {
            List<UserDTO> userdtos = new List<UserDTO>();
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
                        UserDTO userdto = new UserDTO();
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                        userdtos.Add(userdto);
                    }

                }
            }
            return userdtos;
        }

        public UserDTO GetUserByCommentId(int commentid)
        {
            UserDTO userdto = new UserDTO();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM user INNER JOIN comment ON user.Id = @commentid";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@postid", commentid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                    }

                }
            }
            return userdto;
        }

        public UserDTO GetUserByPostId(int postid)
        {
            UserDTO userdto = new UserDTO();
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
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                    }

                }
            }
            return userdto;
        }

        public UserDTO GetUserByUserId(int id)
        {
            UserDTO userdto = new UserDTO();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM user INNER JOIN forum_user ON user.Id = @userid";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                    }

                }
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
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "DELETE INTO forum_user WHERE ForumId = @ForumId AND UserId = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ForumId", forumid);
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UpdateUser_Password(int userid, string password)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "UPDATE forum SET [Password] = @Password WHERE [id] = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descriptions", password);
                    cmd.Parameters.AddWithValue("@id", userid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UserDTO GetUserByUsername(string username)
        {
            UserDTO userdto = new UserDTO();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM user WHERE user.Username = @Username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userdto.Id = reader.GetInt32(0);
                        userdto.Username = reader.GetString(1);
                        userdto.Password = reader.GetString(2);
                        userdto.CreationDate = reader.GetDateTime(3);
                    }

                }
            }

            return userdto;
        }
    }
}
