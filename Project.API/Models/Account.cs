using System;
using System.Collections.Generic;

namespace Project.API.Models
{
     public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Last_active { get; set; }
        public int Status { get; set; }
        public ICollection<Music_type_account> Accounts { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}