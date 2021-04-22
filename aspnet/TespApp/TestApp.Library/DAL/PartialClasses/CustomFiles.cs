using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library.DAL.Models
{
    public partial class CustomFiles
    {
        [NotMapped]
        public bool isActive { get; set; }
        public static async Task<List<CustomFiles>> GetList(TestAppEntities ctx)
        {
            return await (from x in ctx.CustomFiles select x).ToListAsync();
        }

        public static async Task<CustomFiles> GetItem(TestAppEntities ctx, int id)
        {
            return await (from x in ctx.CustomFiles where x.customfile_id == id select x).FirstOrDefaultAsync();
        }

        public static async Task<CustomFiles> Add(TestAppEntities ctx, CustomFiles item)
        {
            ctx.CustomFiles.Add(item);
            await ctx.SaveChangesAsync();

            return item;
        }

        public static async Task<bool> Update(TestAppEntities ctx, CustomFiles item)
        {
            ctx.CustomFiles.Update(item);
            await ctx.SaveChangesAsync();

            return true;
        }

        public static async Task<bool> Delete(TestAppEntities ctx, int id)
        {
            var user_item = await ctx.CustomFiles.SingleOrDefaultAsync(m => m.customfile_id == id);
            ctx.CustomFiles.Remove(user_item);
            await ctx.SaveChangesAsync();

            return true;
        }
    }
}
