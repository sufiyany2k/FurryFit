using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurryFit.Views.Dashboard;
using FurryFit.Views.Forms;
using FurryFit.Views.Home;
using Xamarin.Forms;

namespace FurryFit
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static bool isUserLoggedIn;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAwNTg4QDMxMzgyZTMyMmUzMEVWZHNVTjdyeUdSanFnVW5nNlZBQWoyVDlwYzFSRnl6ZGxEQkxQcDRCeFE9");
            InitializeComponent();
            Device.SetFlags(new string[] { "RadioButton_Experimental" });
            //MainPage = new FurryFit.MainPage();
            MainPage = new HealthCarePage();
            if(App.isUserLoggedIn)
                //App.Current.MainPage = new HomePage();
                App.Current.MainPage = new MDPage();
            else
                App.Current.MainPage = new FurryFit.Views.Forms.SimpleLoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
