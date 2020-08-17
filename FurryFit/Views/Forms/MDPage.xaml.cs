using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Helpers;
using FurryFit.Models;
using NLog;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        //private readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();
        public MDPage()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " Started");
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " Completed");

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as MDPageMasterMenuItem;
                if (item == null)
                    return;
                if (item.TargetType == null)
                    return;

                var page = (Page) Activator.CreateInstance(item.TargetType);
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
            catch (Exception ex)
            {
                App.Logger.Error(ex.Message);
            }
        }
    }
}