using System;

namespace FoodOrderApp.Models
{
    public class FoodItem
    {
        public int ProductID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HomeSelected { get; set; }
        public string Rating { get; set; }
        public string RatingDetail { get; set; }
        public Decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
