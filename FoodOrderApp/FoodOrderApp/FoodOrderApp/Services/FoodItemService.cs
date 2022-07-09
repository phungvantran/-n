using Firebase.Database;
using FoodOrderApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {

            client = new FirebaseClient("https://foodorderapp-d0e82-default-rtdb.firebaseio.com/");
        }
        /// <summary>
        /// Lấy danh dách tất cả các món ăn
        /// </summary>
        /// <returns></returns>
        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems").OnceAsync<FoodItem>()).Select(f => new FoodItem
            {
                CategoryID = f.Object.CategoryID,
                Name = f.Object.Name,
                Description = f.Object.Description,
                HomeSelected = f.Object.HomeSelected,
                ImageUrl = f.Object.ImageUrl,
                Price = f.Object.Price,
                ProductID = f.Object.ProductID,
                Rating = f.Object.Rating,
                RatingDetail = f.Object.RatingDetail,
            }).ToList();
            return products;
        }
        /// <summary>
        /// Lấy danh sách các món ăn theo danh mục
        /// </summary>
        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsBycategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
                foodItemsBycategory.Add(item);
            return foodItemsBycategory;

        }
        /// <summary>
        /// Lấy danh sách các món ăn mới nhất
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
                latestFoodItems.Add(item);
            return latestFoodItems;
        }
    }
}
