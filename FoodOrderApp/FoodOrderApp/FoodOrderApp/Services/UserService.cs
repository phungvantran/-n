using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://foodorderapp-d0e82-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("User")
                .OnceAsync<User>()).Where(u => u.Object.UserName == uname).FirstOrDefault();
            return user != null;
        }
        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (!await IsUserExists(uname))//Chưa tồn tại tk
            {
                await client.Child("User").PostAsync(new User
                {
                    UserName = uname,
                    Password = passwd,
                });
                return true;
            }

            else return false;
        }
        public async Task<bool> LoginUser(string uname, string passwd)
        {
            try
            {
                var user = (await client.Child("User").OnceAsync<User>())
               .Where(u => u.Object.UserName == uname
           ).Where(u => u.Object.Password == passwd).FirstOrDefault();
                return (user != null);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
