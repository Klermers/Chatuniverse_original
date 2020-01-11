using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class UserViewModel
    {
        public int Id
        {
            get;
            private set;
        }
        [Required]
        public string Username
        {
            get;
            private set;
        }
        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            private set;
        }
        public DateTime Date
        {
            get;
            private set;
        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Date = user.Date;
        }

        public UserViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
