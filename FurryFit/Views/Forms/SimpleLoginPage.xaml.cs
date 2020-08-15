using System;
using FurryFit.Views.Dashboard;
using FurryFit.Views.Home;
using FurryFit.Views.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                btnApple.IsVisible = true;
            }
            else
            {
                btnApple.IsVisible = false;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                btnGoogle.IsVisible = true;
            }
            else
            {
                btnGoogle.IsVisible = false;
            }
        }

        private void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            var RegisterPage = new SimpleSignUpPage();
            NavigationPage.SetHasNavigationBar(RegisterPage,false);
            NavigationPage myPage = new NavigationPage(RegisterPage);
            App.Current.MainPage = myPage;

        }

        private void FacebookLoginButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {

            App.isUserLoggedIn = true;
            //App.Current.MainPage= new HomePage();
            App.Current.MainPage = new MDPage();

            //var page = (Page)Activator.CreateInstance(DashboardContent);
            //page.Title = "Home";

            
        }

        private void ForgotPassword_OnTapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new SimpleForgotPasswordPage();
        }
    }
}