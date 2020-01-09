using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ForumDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public ForumDTO()
        {

        }

        public ForumDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ForumDTO(int id)
        {
            Id = id;
        }
    }
}