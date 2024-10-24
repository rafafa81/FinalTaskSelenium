using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTests.Model
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public override string ToString()
        {
            return $"{Username} - {Password}";
        }
    }
}
