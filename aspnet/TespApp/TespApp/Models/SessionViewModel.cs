using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TespApp.Models
{
    public class SessionViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastNames { get; set; }
        public  bool ShowCustomFilesMenu { get; set; }
    }
}
