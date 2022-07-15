using FoodOrderApp.Models;
using FoodOrderApp.Services;
using FoodOrderApp.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class ProductsViewModel:BaseViewModel
    {
        private string _userName;
        private int _userCartItemsCount;
        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string UserName
        {
            get => this._userName;
            set
            {
                this._userName = value;
                OnProPertyChanged();
            }
        }
       /// <summary>
       /// Số món ăn trong giỏ hàng
       /// </summary>
        public int UserCartItemsCount
        {
            get => this._userCartItemsCount;
            set
            {
                this._userCartItemsCount = value;
                OnProPertyChanged();
            }
        }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }

        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }
        public ProductsViewModel()
        {
            var uname = Preferences.Get("UserName", string.Empty);
            if (string.IsNullOrEmpty(uname)) UserName = "Guest:";
            else UserName = uname;

            UserCartItemsCount = new CartItemService().GetUserCartCount();
            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<FoodItem>();
            GetCategories();
            GetLatestItems();

            ViewCartCommand = new Command(async()=> await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetLatestItems()
        {
            var data = await new CategoryDataService().GetCategoryAsync();
            Categories.Clear();
            foreach (var item in data)
                Categories.Add(item);
        }

        private async void GetCategories()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
                LatestItems.Add(item);
        }
    }
}
