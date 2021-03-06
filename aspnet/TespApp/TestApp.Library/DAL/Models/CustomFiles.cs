using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class CustomFiles
    {
        public int customfile_id { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public bool? is_active { get; set; }
        public DateTime created_at { get; set; }
    }
}
