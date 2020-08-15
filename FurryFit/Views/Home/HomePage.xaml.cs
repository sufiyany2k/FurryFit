using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models;
using FurryFit.Views.Dashboard;
using FurryFit.Views.Forms;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            List<MainMenuItem> menuItems = new List<MainMenuItem>();
            MainMenuItem mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Home";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "Self";

            menuItems.Add(mi);
            
            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Add Pet/s";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "SampleView";

            menuItems.Add(mi);

            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Add Vet/s";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "SampleView";
            menuItems.Add(mi);

            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Add Insurance Company";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "SampleView";
            menuItems.Add(mi);

            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "My Details";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "SampleView";
            menuItems.Add(mi);

            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Sync Data";
            mi.ShowToggleSwitch = true;
            mi.TargetPage = "SampleView";
            menuItems.Add(mi);

            mi = new MainMenuItem();
            mi.MenuIcon = "furryfiticon.png";
            mi.MenuItemName = "Log out";
            mi.ShowToggleSwitch = false;
            mi.TargetPage = "SimpleLoginPage";
            menuItems.Add(mi);


            listView.ItemsSource = menuItems;

            //navigationDrawer.ContentView = new HealthCarePage().Content;
            navigationDrawer.ContentView = new DashboardContent().Content;

        }

        private void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuOption = e.SelectedItem as MainMenuItem;
            headerLabel.Text = menuOption.MenuItemName.ToString();

            if (menuOption.MenuItemName.ToString() == "Sync Data")
            {
                navigationDrawer.ToggleDrawer();
                return;
            }


            if (menuOption.MenuItemName.ToString() == "Home")
            {
                navigationDrawer.ContentView = new DashboardContent().Content;
            }
            else if (menuOption.MenuItemName.ToString() == "Log out")
            {
                App.isUserLoggedIn = false;
                App.Current.MainPage = new SimpleLoginPage();
                
            }

            else if (menuOption.MenuItemName.ToString().Contains("Add Pe"))
            {
                navigationDrawer.ContentView = new AddPetProfilePage().Content;
                
            }
            else if (menuOption.MenuItemName.ToString().Contains("Insurance"))
            {
                navigationDrawer.ContentView = new AddInsCompanyPage().Content;

            }
            else if (menuOption.MenuItemName.ToString().Contains("Vet"))
            {
                navigationDrawer.ContentView = new AddVetPage().Content;

            }
            else
            {   navigationDrawer.ContentView = new SampleView().Content;}
            navigationDrawer.ToggleDrawer();
        }



        private void SfSwitch_OnStateChanged(object sender, SwitchStateChangedEventArgs e)
        {
            string Value = string.Empty;
            if (e.NewValue==true)
                Value = "ON";
            else
                Value = "OFF";

            //DisplayAlert("Message", "Data sync has been turned " + Value, "OK");

        }
    }
}