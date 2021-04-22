using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Library.DAL.Models
{
    public partial class Users
    {
        [NotMapped]
        public bool isActive { get; set; }

        [NotMapped]
        public string FullName { get { return $"{this.first_names} {this.last_names}"; }  }

        public static async Task<List<Users>> GetList(TestAppEntities ctx)
        {
            return await (from x in ctx.Users select x).ToListAsync();
        }
        public static async Task<Users> GetItem(TestAppEntities ctx, int user_id)
        {
            return await (from x in ctx.Users where x.user_id == user_id select x).FirstOrDefaultAsync();
        }
        public static async Task<Users> GetItem(TestAppEntities ctx, string email)
        {
            return await (from x in ctx.Users where x.email == email select x).FirstOrDefaultAsync();
        }
        public static async Task<Users> Add(TestAppEntities ctx, Users item)
        {
            ctx.Users.Add(item);
            await ctx.SaveChangesAsync();
            return item;
        }
        public static async Task<bool> Update(TestAppEntities ctx, Users item)
        {
            try
            {
                ctx.Update(item);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                // TODO: Log error.
                return false;
            }
        }
        public static async Task<bool> Delete(TestAppEntities ctx, int user_id)
        {
            try
            {
                var item = await (from x in ctx.Users where x.user_id == user_id select x).FirstOrDefaultAsync();
                ctx.Users.Remove(item);
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
