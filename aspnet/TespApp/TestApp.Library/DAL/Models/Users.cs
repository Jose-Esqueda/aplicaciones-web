using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class Users
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_names { get; set; }
        public string last_names { get; set; }
        public bool? is_active { get; set; }
        public DateTime created_at { get; set; }
    }
}
