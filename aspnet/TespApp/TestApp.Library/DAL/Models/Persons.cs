using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class Persons
    {
        public int person_id { get; set; }
        public string email { get; set; }
        public string first_names { get; set; }
        public string last_names { get; set; }
        public bool? is_active { get; set; }
        public DateTime created_at { get; set; }
    }
}
