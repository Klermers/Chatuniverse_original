using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using MySql.Data.MySqlClient;
using ChatUniverseInterface;

namespace Data_Acces_Layer.SQL
{
    public class CommentSQL : ICommentContext
    {
        MySqlConnection conn;
        string connectionstring = "Server=studmysql01.fhict.local;Uid=dbi393712;Database=dbi393712;Pwd=catlover1214;";

        public void CreateComment(string comment, int postid, int userid)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "INSERT INTO Comment(comment,Postid,userid,date) VALUES(@Comment,@Postid,@Userid,@Date)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Comment", comment);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Parameters.AddWithValue("@Postid", postid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteComment(int id)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                string query = "DELETE FROM comment WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CommentDTO> GetAllCommentsByPostId(int postid)
        {
            List<CommentDTO> commentdtos = new List<CommentDTO>();
            try
            {
                using (conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * from comment INNER JOIN post ON comment.Postid = post.id ORDER BY comment.Date";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postid", postid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Text = reader.GetString(1);
                            DateTime Date = reader.GetDateTime(2);
                            CommentDTO commentdto = new CommentDTO(Id, Text, Date);

                            commentdtos.Add(commentdto);
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                commentdtos = null;
            }
            return commentdtos;
        }

        public void UpdateComment_Comment(int commentid, string comment)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "UPDATE comment SET comment = @Comment WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Comment", comment);
                    cmd.Parameters.AddWithValue("@id", commentid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
