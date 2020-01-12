using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using MySql.Data.MySqlClient;
using ChatUniverseInterface;

namespace Data_Acces_Layer.SQL
{
    public class PostSQL : IPostContext
    {
        MySqlConnection conn;
        string connectionstring = "Server=studmysql01.fhict.local;Uid=dbi393712;Database=dbi393712;Pwd=catlover1214;";

        public void CreatePost(int forumid, string titel, int userid)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "iNSERT INTO Post(posttitel,forum,userid,Date) VALUES(@Titel,@Forum,@Userid,@Date)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titel", titel);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Parameters.AddWithValue("@Forum", forumid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePost(int id)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "DELETE FROM post WHERE [id] = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PostDTO> GetAllPosts()
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = forum.id ORDER BY post.posttitel";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PostDTO postdto = new PostDTO();
                        postdto.Id = reader.GetInt32(0);
                        postdto.PostTitel = reader.GetString(1);
                        postdto.Date = reader.GetDateTime(2);
                        postdto.Upvotes = reader.GetInt32(3);
                        postdtos.Add(postdto);
                    }
                }
            }
            return postdtos;
        }

        public List<PostDTO> GetAllPostsByForumId(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = forum.Id WHERE post.forum =@forumid  ORDER BY post.posttitel";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@forumid", forumid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PostDTO postdto = new PostDTO();
                        postdto.Id = reader.GetInt32(0);
                        postdto.PostTitel = reader.GetString(1);
                        postdto.Date = reader.GetDateTime(2);
                        postdtos.Add(postdto);
                    }
                }
            }
            return postdtos;
        }

        public List<PostDTO> GetAllPostsByForumIdDesc(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = @forumid ORDER BY post.posttitel DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@forumid", forumid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PostDTO postdto = new PostDTO();
                        postdto.Id = reader.GetInt32(0);
                        postdto.PostTitel = reader.GetString(1);
                        postdto.Date = reader.GetDateTime(2);
                        postdto.Upvotes = reader.GetInt32(3);
                        postdtos.Add(postdto);
                    }
                }
            }
            return postdtos;
        }

        public List<PostDTO> GetAllPostsDesc()
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = forum.id ORDER BY post.posttitel DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PostDTO postdto = new PostDTO();
                        postdto.Id = reader.GetInt32(0);
                        postdto.PostTitel = reader.GetString(1);
                        postdto.Date = reader.GetDateTime(2);
                        postdto.Upvotes = reader.GetInt32(3);
                        postdtos.Add(postdto);
                    }
                }
            }
            return postdtos;
        }

        public PostDTO GetPostById(int postid)
        {
            PostDTO postdto = new PostDTO();
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * from post WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", postid);
                    var reader = cmd.ExecuteReader(); ;
                    while (reader.Read())
                    {
                        postdto.Id = reader.GetInt32(0);
                        postdto.PostTitel = reader.GetString(1);
                        postdto.Date = reader.GetDateTime(2);
                    }
                }
            }
            return postdto;
        }

        public void UpdatePost_Upvotes(int upvote, int postid)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "UPDATE post SET [upvotes] = [upvotes] + @upvote WHERE [id] = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", postid);
                    cmd.Parameters.AddWithValue("@upvote", upvote);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
