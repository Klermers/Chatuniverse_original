using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public UserDTO()
        {

        }

        public UserDTO(int id, string username, string password, DateTime creationdate)
        {
            Id = id;
            Username = username;
            Password = password;
            CreationDate = creationdate;
        }


        public UserDTO(string username, string password, DateTime creationdate)
        {
            Username = username;
            Password = password;
            CreationDate = creationdate;
        }

    }
}
