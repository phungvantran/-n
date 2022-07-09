using Firebase.Database;
using FoodOrderApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://foodorderapp-d0e82-default-rtdb.firebaseio.com/");
        }
        /// <summary>
        ///Lấy dữ liệu  các danh mục  món ăn
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetCategoryAsync()
        {
            var categories = (await client.Child("Categories").OnceAsync<Category>()).Select(c => new Category
            {
                CategoryID = c.Object.CategoryID,
                CategoryName = c.Object.CategoryName,
                CategoryPoster = c.Object.CategoryPoster,
                ImageUrl = c.Object.ImageUrl,
            }).ToList();
            return categories;
        }
    }
}
