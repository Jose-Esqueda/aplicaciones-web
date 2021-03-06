using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TespApp.Models
{
    public class UsersIndexViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Fullname { get; set; }

        public UsersIndexViewModel(string username, string name, string lastname, string email, int age, DateTime createdAt, bool isActive)
        {
            this.Username = username;
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
            this.Age = age;
            this.CreatedAt = createdAt;
            this.IsActive = isActive;

            this.Fullname = String.Format("{0} {1}", name, lastname);
        }
    }
}
