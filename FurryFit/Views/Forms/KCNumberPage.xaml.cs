using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.ViewModels.Pets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KCNumberPage : ContentPage
    {
        private PetKennelInfoVM petKennelInfoVm;
        public KCNumberPage(int petId)
        {
            InitializeComponent();
            petKennelInfoVm = new PetKennelInfoVM(petId);
            this.BindingContext = petKennelInfoVm;
        }

        private async void SfButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}