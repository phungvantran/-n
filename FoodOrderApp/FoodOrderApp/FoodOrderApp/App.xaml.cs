using FoodOrderApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new ProductsView());
            var uname = Preferences.Get("UserName", string.Empty);
            if (string.IsNullOrEmpty(uname)) MainPage = new NavigationPage(new LoginView());
            else MainPage = new NavigationPage(new ProductsView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
