using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FurryFit.Database;
using FurryFit.Helpers;
using FurryFit.Repository.Interface;
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
        public static NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static string dbPath;
        public static string imageCopyPath;
        static FurryFitDB database;

        public static FurryFitDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new FurryFitDB(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAwNTg4QDMxMzgyZTMyMmUzMEVWZHNVTjdyeUdSanFnVW5nNlZBQWoyVDlwYzFSRnl6ZGxEQkxQcDRCeFE9");
            if (Device.RuntimePlatform == Device.Android)
            {
                dbPath =
                    System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "furryFitDB.db");
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                dbPath =
                    System.IO.Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Library", "furryFitDB.db");
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                imageCopyPath =
                    System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Pics");
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                imageCopyPath =
                    System.IO.Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Pics");
            }

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
