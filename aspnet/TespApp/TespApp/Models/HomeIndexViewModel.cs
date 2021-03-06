using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TespApp.Models
{
    public class HomeIndexViewModel
    {
        public string UserName { get; set; }
        public DateTime DateTimeNow { get; set; }
        public int DayNumber { get; set; }
        public HomeIndexViewModelPartial ItemPartial { get; set; }

        public HomeIndexViewModel()
        {
            ItemPartial = new HomeIndexViewModelPartial();
        }
    }

    public class HomeIndexViewModelPartial
    {
        public string Classroom { get; set; }
    }
}
