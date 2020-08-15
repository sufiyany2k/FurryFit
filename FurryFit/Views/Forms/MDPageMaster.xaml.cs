using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models;
using FurryFit.Views.Dashboard;
using FurryFit.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;
        public ObservableCollection<MainMenuItem> MainMenuItems { get; set; }
        public MDPageMaster()
        {
            InitializeComponent();
            //MainMenuItems = new ObservableCollection<MainMenuItem>();
            //List<MainMenuItem> menuItems = new List<MainMenuItem>();
            //MainMenuItem mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Home";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "Self";
            //mi.TargetType = typeof(DashboardContent);

            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Add Pet/s";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "SampleView";
            //mi.TargetType = typeof(AddPetProfilePage);

            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Add Vet/s";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "SampleView";
            //mi.TargetType = typeof(AddVetPage);
            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Add Insurance Company";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "SampleView";
            //mi.TargetType = typeof(AddInsCompanyPage);
            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "My Details";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "SampleView";
            //mi.TargetType = typeof(SampleView);

            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Sync Data";
            //mi.ShowToggleSwitch = true;
            //mi.TargetPage = "SampleView";

            //MainMenuItems.Add(mi);

            //mi = new MainMenuItem();
            //mi.MenuIcon = "furryfiticon.png";
            //mi.MenuItemName = "Log out";
            //mi.ShowToggleSwitch = false;
            //mi.TargetPage = "SimpleLoginPage";
            //mi.TargetType = typeof(SimpleLoginPage);

            //MainMenuItems.Add(mi);


            BindingContext = new MDPageMasterViewModel();
            
            ListView = MenuItemsListView;
        }

        class MDPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMasterMenuItem> MenuItems { get; set; }

            public MDPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMasterMenuItem>(new[]
                {
                    new MDPageMasterMenuItem { Id = 0, Title = "Home", MenuIcon = "furryfitlogo.png", ShowToggleSwitch = false, TargetType = typeof(DashboardContent)},
                    new MDPageMasterMenuItem { Id = 1, Title = "Add Pet/s", MenuIcon = "furryfitlogo.png", ShowToggleSwitch = false, TargetType = typeof(AddPetProfilePage) },
                    new MDPageMasterMenuItem { Id = 2, Title = "Add Vet/s", MenuIcon = "vet.png", ShowToggleSwitch = false, TargetType = typeof(AddVetPage) },
                    new MDPageMasterMenuItem { Id = 3, Title = "Add Insurance Company", MenuIcon = "insurance.png", ShowToggleSwitch = false, TargetType = typeof(AddInsCompanyPage) },
                    new MDPageMasterMenuItem { Id = 4, Title = "My Details", MenuIcon = "furryfitlogo.png", ShowToggleSwitch = false, TargetType = typeof(SampleView) },
                    new MDPageMasterMenuItem { Id = 5, Title = "Sync Data", MenuIcon = "furryfitlogo.png", ShowToggleSwitch = true, TargetType = null },
                    new MDPageMasterMenuItem { Id = 6, Title = "Log out", MenuIcon = "furryfitlogo.png", ShowToggleSwitch = false, TargetType = typeof(SimpleLoginPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}