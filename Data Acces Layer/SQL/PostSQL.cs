﻿using System;
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
        IConnectionString Connectionstring;

        public PostSQL(IConnectionString connmectionstring)
        {
            Connectionstring = connmectionstring;
        }

        public void CreatePost(int forumid, string titel, int userid)
        {
            using (conn = new MySqlConnection(Connectionstring.Connstring))
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
            using (conn = new MySqlConnection(Connectionstring.Connstring))
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

        public List<PostDTO> GetAllPostsByForumId(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = forum.Id WHERE post.forum =@forumid  ORDER BY post.posttitel";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@forumid", forumid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string PostTitel = reader.GetString(1);
                            DateTime Date = reader.GetDateTime(2);
                            PostDTO postdto = new PostDTO(Id, PostTitel, Date);
                            postdtos.Add(postdto);
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                postdtos = null;
            }
            return postdtos;
        }

        public List<PostDTO> GetAllPostsByForumIdDesc(int forumid)
        {
            List<PostDTO> postdtos = new List<PostDTO>();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM `post` INNER JOIN forum ON post.forum = @forumid ORDER BY post.posttitel DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@forumid", forumid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string PostTitel = reader.GetString(1);
                            DateTime Date = reader.GetDateTime(2);
                            PostDTO postdto = new PostDTO(Id, PostTitel, Date);
                            postdtos.Add(postdto);
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                postdtos = null;
            }
            return postdtos;
        }

        public PostDTO GetPostById(int postid)
        {
            PostDTO postdto = new PostDTO();
            try
            {
                using (conn = new MySqlConnection(Connectionstring.Connstring))
                {
                    conn.Open();
                    string query = "SELECT * from post WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", postid);
                        var reader = cmd.ExecuteReader(); ;
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string PostTitel = reader.GetString(1);
                            DateTime Date = reader.GetDateTime(2);
                            postdto = new PostDTO(Id, PostTitel, Date);
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                postdto = null;
            }
            return postdto;
        }
    }
}
