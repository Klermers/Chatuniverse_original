using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CommentDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int Upvotes
        {
            get;
            set;
        }

        public CommentDTO()
        {

        }

        public CommentDTO(int id, string text, DateTime date, int upvotes)
        {
            Id = id;
            Text = text;
            Date = date;
            Upvotes = upvotes;
        }

        public CommentDTO(string text)
        {
            Text = text;
        }

        public CommentDTO(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
