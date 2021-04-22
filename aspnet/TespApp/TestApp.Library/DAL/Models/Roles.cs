using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class Roles
    {
        public int role_id { get; set; }
        public string description { get; set; }
        public bool? is_active { get; set; }
    }
}
