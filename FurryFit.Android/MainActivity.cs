using System;
using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using FurryFit.DB.Repository;
using System.IO;
using Android.Gms.Ads;
using Plugin.CurrentActivity;
using Plugin.Media;
using Plugin.Permissions;
using Environment = System.Environment;

namespace FurryFit.AndroidXam
//namespace FurryFit.Droid1
{
    [Activity(Label = "FurryFit", Icon = "@drawable/furryfitlogo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-8903360911463629~3292933128");

            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            //await CrossMedia.Current.Initialize();
            CrossCurrentActivity.Current.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            InitializeNLog();
            LoadApplication(new App());
        }
        private void InitializeNLog()
        {
            Assembly assembly = this.GetType().Assembly;
            string assemblyName = assembly.GetName().Name;
            new Helpers.LogService().Initialize(assembly, assemblyName);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

