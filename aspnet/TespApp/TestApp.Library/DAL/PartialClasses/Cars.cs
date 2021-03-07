using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Library.DAL.Models
{
    public partial class Cars
    {
        [NotMapped]
        public bool isActive { get; set; }

        public static async Task<List<Cars>> GetList(TestAppEntities ctx)
        {
            return await (from x in ctx.Cars select x).ToListAsync();
        }
        public static async Task<Cars> GetItem(TestAppEntities ctx, int user_id)
        {
            return await (from x in ctx.Cars where x.car_id == user_id select x).FirstOrDefaultAsync();
        }
        public static async Task<Cars> Add(TestAppEntities ctx, Cars item)
        {
            ctx.Cars.Add(item);
            await ctx.SaveChangesAsync();
            return item;
        }
        public static async Task<bool> Update(TestAppEntities ctx, Cars item)
        {
            try
            {
                ctx.Update(item);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log error.
                return false;
            }
        }
        public static async Task<bool> Delete(TestAppEntities ctx, int user_id)
        {
            try
            {
                var item = await (from x in ctx.Cars where x.car_id == user_id select x).FirstOrDefaultAsync();
                ctx.Cars.Remove(item);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log error.
                return false;
            }
        }
    }
}
