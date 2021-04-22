using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Library.DAL.Models
{
    public partial class Roles
    {
        public static async Task<List<Roles>> GetList(TestAppEntities ctx)
        {
            return await (from x in ctx.Roles select x).ToListAsync();
        }
    }
}
