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
            set;
        }
        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            private set;
        }

        public bool IsUserForumMember
        {
            get;
            private set;
        }

        public UserViewModel()
        {

        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Date = user.Date;
        }

        public UserViewModel(User user, bool isuserforummember)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Date = user.Date;
            IsUserForumMember = IsUserForumMember;
        }

        public UserViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
