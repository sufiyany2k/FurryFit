using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        public MDPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MDPageMasterMenuItem;
            if (item == null)
                return;
            if (item.TargetType == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            if (item.Title.Contains("Add"))
            {
                IsPresented = false;
                Navigation.PushModalAsync(page);
            }
            else
            {
                Detail = new NavigationPage(page);
                IsPresented = false;
            }

            MasterPage.ListView.SelectedItem = null;
        }
    }
}