using SQLite;
using System;

namespace FoodOrderApp.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement,PrimaryKey]
        public int CartItemId { get; set; }
        public int ProductId{ get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Quantity {get; set; }
    }
}
