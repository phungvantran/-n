using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems;
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderapp-d0e82-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>
            {
                new FoodItem
                {
                    ProductID=0,
                    CategoryID=1,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=1,
                    CategoryID=1,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=2,
                    CategoryID=2,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=3,
                    CategoryID=2,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=4,
                    CategoryID=2,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=5,
                    CategoryID=3,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },new FoodItem
                {
                    ProductID=6,
                    CategoryID=3,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=7,
                    CategoryID=3,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },
                new FoodItem
                {
                    ProductID=8,
                    CategoryID=1,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                },new FoodItem
                {
                    ProductID=8,
                    CategoryID=1,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                }
                ,new FoodItem
                {
                    ProductID=10,
                    CategoryID=2,
                    ImageUrl="https://recmiennam.com/wp-content/uploads/2020/10/kiet-tac-cua-thien-nhien-qua-nhung-hinh-anh-dep-7-scaled.jpg",
                    Name="Burger and Pizza Hub 1",
                    Description="Burger-Pizza-Breakfast"
                    ,Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45,

                }
            };
        }
        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        ProductID = item.ProductID,
                        CategoryID = item.CategoryID,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price,

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
