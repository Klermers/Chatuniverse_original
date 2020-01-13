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
        string connectionstring = "Server=studmysql01.fhict.local;Uid=dbi393712;Database=dbi393712;Pwd=catlover1214;";

        /*public ForumSQL()
        {

        }

        public ForumSQL(string connstring)
        {
            connectionstring = connstring;
        }
        */

        public void CreateForum(string name, string description)
        {
            using (conn = new MySqlConnection(connectionstring))
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

        public void DeleteForum(int id)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "DELETE FROM forum WHERE [id] = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //This forum gets single forum information
        public ForumDTO GetForumById(int id)
        {
            ForumDTO forumdto = new ForumDTO();
            using (conn = new MySqlConnection(connectionstring))
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
                        forumdto = new ForumDTO(Id,Name,Description);
                    }
                }
            }
            return forumdto;
        }

        //this method updates the discription of a signle forum
        public void UpdateForum_Description(int id, string description)
        {
            using (conn = new MySqlConnection(connectionstring))
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
            using (conn = new MySqlConnection(connectionstring))
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
                        ForumDTO forumdto = new ForumDTO(Id,Name,Description);
                        forumdtos.Add(forumdto);
                    }

                }
            }
            return forumdtos;
        }

        public List<ForumDTO> GetAllForumsDesc()
        {
            List<ForumDTO> forumdtos = new List<ForumDTO>();
            using (conn = new MySqlConnection(connectionstring))
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
                        ForumDTO forumdto = new ForumDTO(Id,Name,Description);
                        forumdtos.Add(forumdto);
                    }

                }
            }
            return forumdtos;
        }
    }
}
