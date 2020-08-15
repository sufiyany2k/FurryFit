using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionalInfoPage : ContentPage
    {
        public AdditionalInfoPage()
        {
            InitializeComponent();
        }

        private async void SfButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new KCNumberPage());
        }

        private async void SfButton1_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);

        }
    }
}