using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FurryFit.Views.Forms
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
        public SimpleSignUpPage()
        {
            InitializeComponent();
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SimpleLoginPage();
        }

        private void RegisterButton_OnClicked(object sender, EventArgs e)
        {

            App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Started");
            try
            {
                validateEntries();
            }
            catch (Exception ex)
            {
                App.Logger.Error(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                DisplayAlert("Error", ex.Message, "ok");

            }
            finally
            {
                App.Logger.Info(this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Completed");
            }

        }

        private void validateEntries()
        {

        }

    }
}