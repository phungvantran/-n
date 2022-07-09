using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddCategoryData
    {
        FirebaseClient client;
        public List<Category> Categories { get; set; }
        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderapp-d0e82-default-rtdb.firebaseio.com/");
            Categories = new List<Category>
            {
                new Category{CategoryID=0,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
                new Category{CategoryID=1,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
                new Category{CategoryID=2,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
                new Category{CategoryID=3,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
                new Category{CategoryID=4,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
                new Category{CategoryID=5,CategoryName="Pizza",CategoryPoster="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg"},
            };

        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl,
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
