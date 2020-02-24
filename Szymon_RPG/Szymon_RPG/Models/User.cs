using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string pass) {

            Login = username;
            Password = pass;
        }

        public bool checkInformation()
        {
            if (Login.Equals("") || Password.Equals(""))
                return false;
            return true; 
        }

    }
}
