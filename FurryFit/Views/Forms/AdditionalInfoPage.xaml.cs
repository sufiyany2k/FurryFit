using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Repository;
using FurryFit.ViewModels.Pets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionalInfoPage : ContentPage
    {
        private PetAdditionInfoVM petAdditionInfoVm ;
        private int _petId;
        public AdditionalInfoPage(int petId)
        {
            InitializeComponent();
            _petId = petId;
            petAdditionInfoVm = new PetAdditionInfoVM(petId);
            this.BindingContext = petAdditionInfoVm;

        }

        private async void SfButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new KCNumberPage(_petId));
        }

        private async void SfButton1_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);

        }
    }
}