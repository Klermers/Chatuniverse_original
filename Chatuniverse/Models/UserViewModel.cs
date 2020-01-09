using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Username
        {
            get;
            private set;
        }
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
    }
}
