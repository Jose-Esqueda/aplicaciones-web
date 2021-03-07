using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class Cars
    {
        public int car_id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public bool? is_active { get; set; }
        public DateTime created_at { get; set; }
    }
}
