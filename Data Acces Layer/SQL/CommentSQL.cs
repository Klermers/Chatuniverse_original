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
                string query = "iNSERT INTO Comment(comment,Postid,userid,date) VALUES(@Comment,@Postid,@Userid,@Date)";
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
                string query = "DELETE FROM comment WHERE [id] = @id";
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

            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT * from comment INNER JOIN post ON comment.id = @postid ORDER BY comment.Date";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@postid", postid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CommentDTO commentdto = new CommentDTO();
                        commentdto.Id = reader.GetInt32(0);
                        commentdto.Text = reader.GetString(1);
                        commentdto.Date = reader.GetDateTime(2);
                        commentdto.Upvotes = reader.GetInt32(3);

                        commentdtos.Add(commentdto);
                    }
                }
            }
            return commentdtos;
        }

        public void UpdateComment_Comment(int commentid, string comment)
        {
            using (conn = new MySqlConnection(connectionstring))
            {
                conn.Open();
                string query = "UPDATE comment SET [comment] = @Comment WHERE [id] = @id";
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
