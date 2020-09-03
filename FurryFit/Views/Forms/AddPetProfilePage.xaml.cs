using System;
using System.IO;
using FurryFit.ViewModels.Pets;
using FurryFit.Views.Dashboard;
using Plugin.Media;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using DateChangedEventArgs = Syncfusion.XForms.Pickers.DateChangedEventArgs;

namespace FurryFit.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPetProfilePage : ContentPage
    {
        PetProfileViewModel p = new PetProfileViewModel();
        public AddPetProfilePage()
        {
            InitializeComponent();
            DatePicker.MaximumDate = DateTime.Now.Date;
            
            BindingContext = p;
            p.Name.Value = "test";
        }

        public AddPetProfilePage(PetProfileViewModel pet)
        {
            InitializeComponent();
            BindingContext = pet;
        }

        private void ChkBoxMale_OnFocused(object sender, FocusEventArgs e)
        {
        }

        private void ChkBoxFemale_OnFocused(object sender, FocusEventArgs e)
        {
        }

        private void VisualElement_OnFocused(object sender, FocusEventArgs e)
        {
        }

        private void ChkBoxNo1_OnFocused(object sender, FocusEventArgs e)
        {
        }

        private void ChkBoxNo1_OnUnfocused(object sender, FocusEventArgs e)
        {
        }

        private void BtnCancel_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);

        }



        private void EntryPetName_OnFocused(object sender, FocusEventArgs e)
        {
           //p.PetName.Validate();
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Permission Error", "Unable to select Photo", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CustomPhotoSize = 50,
                CompressionQuality = 50,

            });
            if (file == null)
                return;



            dpPic.ImageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                p.PetImagePath.Value = file.Path;
                p.PetImageStream.Value = stream;
                file.Dispose();
                return stream;
            });

            //var dirToCreate = Path.Combine(App.imageCopyPath, "PetDPs");
            //if (!Directory.Exists(dirToCreate))
            //{
            //    Directory.CreateDirectory(dirToCreate);
            //}
            //// Make a new path to compine the dir and the fileName
            //string destFolder = Path.Combine(dirToCreate, file.Name);
            //System.IO.File.Copy(file.FilePath, destFolder, true);
            ////}

        }
    }
}