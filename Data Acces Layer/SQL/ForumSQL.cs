using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DTO;
using ChatUniverseInterface;

namespace Data_Acces_Layer.SQL
{
    public class ForumSQL : IForumContext
    {
        MySqlConnection conn;
        IConnectionString Connectionstring;

        public ForumSQL(IConnectionString connmectionstring)
        {
            Connectionstring = connmectionstring;
        }

        public void CreateForum(string name, string description)
        {
            using (conn = new MySqlConnection(Connectionstring.Connstring))
            {
                conn.Open();
                string query = "INSERT INTO Forum(Name,Description) VALUES(@Name,@Description)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //This forum gets single forum information
        public ForumDTO GetForumById(int id)
        {
            ForumDTO forumdto = new ForumDTO();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    conn.Open();
                    string query = "SELECT * from forum WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            string Description = reader.GetString(4);
                            forumdto = new ForumDTO(Id, Name, Description);
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                forumdto = null;
            }
            return forumdto;
        }

        //this method updates the discription of a signle forum
        public void UpdateForum_Description(int id, string description)
        {
            using (conn = new MySqlConnection(Connectionstring.Connstring))
            {
                conn.Open();
                string query = "UPDATE forum SET [Description] = @Description WHERE [id] = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descriptions", description);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //GetAllForums out of the DataBase
        public List<ForumDTO> GetAllForums()
        {
            List<ForumDTO> forumdtos = new List<ForumDTO>();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    string query = "SELECT * FROM `forum` LEFT JOIN post ON forum.Id = post.forum ORDER BY forum.Name";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            string Description = reader.GetString(4);
                            ForumDTO forumdto = new ForumDTO(Id, Name, Description);
                            forumdtos.Add(forumdto);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                forumdtos = null;
            }
            return forumdtos;
        }

        public List<ForumDTO> GetAllForumsDesc()
        {
            List<ForumDTO> forumdtos = new List<ForumDTO>();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    string query = "SELECT * FROM `forum` LEFT JOIN post ON forum.Id = post.forum ORDER BY forum.Name DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            string Description = reader.GetString(4);
                            ForumDTO forumdto = new ForumDTO(Id, Name, Description);
                            forumdtos.Add(forumdto);
                        }

                    }
                }
            }
            catch(NullReferenceException)
            {
                forumdtos = null;
            }
            return forumdtos;
        }
    }
}
