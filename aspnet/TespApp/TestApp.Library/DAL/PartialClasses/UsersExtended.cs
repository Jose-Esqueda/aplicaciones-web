using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Library.DAL.Models
{
    public partial class UsersExtended
    {
        [NotMapped]
        public string role_description { get; set; }
        [NotMapped]
        public bool isActive { get; set; }

        [NotMapped]
        public string FullName { get { return $"{this.first_names} {this.last_names}"; }  }

        public static async Task<List<UsersExtended>> GetList(TestAppEntities ctx)
        {
            return await (from x in ctx.UsersExtended select x).ToListAsync();
        }
        public static async Task<List<UsersExtended>> GetListExtended(TestAppEntities ctx)
        {
            return await (from x in ctx.UsersExtended
                          join r in ctx.Roles on x.role_id equals r.role_id
                          select new UsersExtended()
                          {
                              user_id = x.user_id,
                              role_id = x.role_id,
                              role_description = r.description,
                              email = x.email,
                              first_names = x.first_names,
                              last_names = x.last_names,
                              is_active = x.is_active,
                              created_at = x.created_at,
                              
                          }).ToListAsync();
        }
        public static async Task<UsersExtended> GetItem(TestAppEntities ctx, int user_id)
        {
            return await (from x in ctx.UsersExtended where x.user_id == user_id select x).FirstOrDefaultAsync();
        }
        public static async Task<UsersExtended> GetItem(TestAppEntities ctx, string email)
        {
            return await (from x in ctx.UsersExtended where x.email == email select x).FirstOrDefaultAsync();
        }
        public static async Task<UsersExtended> Add(TestAppEntities ctx, UsersExtended item)
        {
            ctx.UsersExtended.Add(item);
            await ctx.SaveChangesAsync();
            return item;
        }
        public static async Task<bool> Update(TestAppEntities ctx, UsersExtended item)
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
                var item = await (from x in ctx.UsersExtended where x.user_id == user_id select x).FirstOrDefaultAsync();
                ctx.UsersExtended.Remove(item);
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
