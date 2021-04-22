using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestApp.Library.DAL.Models;

namespace TestApp.Library.BLL
{
    public class Session
    {
        public static async Task<Tuple<Users, string>> AddUser(TestAppEntities ctx, Users item)
        {
            try
            {
                var user_found = await Users.GetItem(ctx, item.email);
                if (user_found == null)
                {
                    item.password = GeneratePassword(item.password);

                    var result = await Users.Add(ctx, item);
                    if (result.user_id > 0)
                        return Tuple.Create(result, String.Empty);
                    else
                        return Tuple.Create(new Users(), "Ocurrio un error.");
                }
                else
                    return Tuple.Create(new Users(), "Email repetido.");
            }
            catch (Exception)
            {
                // Log error.
                return Tuple.Create(new Users(), "Ocurrio un error.");
            }
        }

        public static string GeneratePassword(string password)
        {
            byte[] salt = GenerateRandomBytes();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hash_bytes = new byte[36];

            Array.Copy(salt, 0, hash_bytes, 0, 16);
            Array.Copy(hash, 0, hash_bytes, 16, 20);

            string password_hash = Convert.ToBase64String(hash_bytes);

            return password_hash;
        }

        private static byte[] GenerateRandomBytes()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return salt;
        }


        public static async Task<Tuple<Users, string>> ValidateCredentials(TestAppEntities ctx, string email, string password)
        {
            string message = String.Empty;
            var user = await Users.GetItem(ctx, email);
            if (user != null)
            {
                if(true)
                {
                    if (user.is_active == true)
                    {

                    }
                    else
                        message = "User inactive.";
                }
                else
                    message = "Email or password incorrect.";
            }
            else
                message = "Email or password incorrect.";


            return Tuple.Create(user, message);
        }

        private static bool ValidatePassword(string password_input, string password_db)
        {
            // Obtain bytes from hashed password.
            byte[] password_db_hash = Convert.FromBase64String(password_db);

            byte[] salt = new byte[16];
            Array.Copy(password_db_hash, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password_input, salt, 10000);
            byte[] password_input_hash = pbkdf2.GetBytes(20);

            bool is_valid = true;
            for (int i = 0; i < 20; i++)
            {
                if (password_db_hash[i + 16] != password_input_hash[i])
                {
                    is_valid = false;
                    break;
                }
            }

            return is_valid;
        }
    }
}
