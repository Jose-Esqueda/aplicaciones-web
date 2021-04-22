using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Library.DAL.Models;

namespace TespApp.Models
{
    public class CustomFilesCreateViewModel : CustomFiles
    {
        public IFormFile file { get; set; }
    }
}
