using FoodOrderApp.Services;
using FoodOrderApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private bool _isBusy;
        private bool _result;
        /// <summary>
        /// Tên đăng nhập
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
        /// Mật khẩu
        /// </summary>
        public string Password
        {
            get => this._password;
            set
            {
                this._password = value;
                OnProPertyChanged();
            }
        }

        public bool IsBusy
        {
            get => this._isBusy;
            set
            {
                try
                {
                    this._isBusy = value;
                    OnProPertyChanged();
                }
                catch (Exception e)
                {

                }
            }
        }

        public bool Result
        {
            get => this._result;
            set
            {
                this._result = value;
                OnProPertyChanged();
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
        }

        private async Task Login()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(UserName, Password);
                if (Result)
                {
                    Preferences.Set("UserName", UserName);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid UserName or Password", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task Register()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(UserName, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exist with this credentials", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
