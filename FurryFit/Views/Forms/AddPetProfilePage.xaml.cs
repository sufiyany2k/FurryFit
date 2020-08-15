using System;
using FurryFit.Views.Dashboard;
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
        public AddPetProfilePage()
        {
            InitializeComponent();
            DatePicker.MaximumDate = DateTime.Now.Date;
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
    }
}