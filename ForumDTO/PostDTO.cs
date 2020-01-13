using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PostDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string PostTitel
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

        public PostDTO()
        {

        }

        public PostDTO(int id, string posttitel, DateTime date)
        {
            Id = id;
            PostTitel = posttitel;
            Date = date;
        }
    }
}
