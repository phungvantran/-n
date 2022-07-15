using FoodOrderApp.Models;
using FoodOrderApp.Services;
using System.Collections.ObjectModel;

namespace FoodOrderApp.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        private Category _selectedCategory;
        private int _totalFoodItems;
        /// <summary>
        /// Item danh mục đang được chọn
        /// </summary>
        public Category SelectedCategory
        {
            get => this._selectedCategory;
            set
            {
                this._selectedCategory = value;
                OnProPertyChanged();
            }
        }
       
        /// <summary>
        /// Số item trong danh mục
        /// </summary>
        public int TotalFoodItems
        {
            get => this._totalFoodItems;
            set
            {
                this._totalFoodItems = value;
                OnProPertyChanged();
            }
        }
        /// <summary>
        /// List món ăn trong danh mục dược chọn
        /// </summary>
        public ObservableCollection<FoodItem> FoodItemsByCategory { get; set; }
        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            FoodItemsByCategory = new ObservableCollection<FoodItem>();
            GetFoodItems(category.CategoryID);
        }
        /// <summary>
        /// Lấy danh sach các món ăn theo id danh mục
        /// </summary>
        /// <param name="categoryID"></param>
        private async void GetFoodItems(int categoryID)
        {
            var data= await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
            FoodItemsByCategory.Clear();
            foreach (var item in data)
                FoodItemsByCategory.Add(item);
            TotalFoodItems = FoodItemsByCategory.Count; 
        }
    }
}
