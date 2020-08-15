using System;
using System.Text;
using FurryFit.Models.DBEntities;
using FurryFit.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FurryFit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields

        private string name;

        private string password;

        private string confirmPassword;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                if (String.IsNullOrEmpty(this.Name) || this.Name.Length < 3)
                    ValidationError = "Please enter a valid Name";

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }
                if (String.IsNullOrEmpty(value) )
                    ValidationError = "password cannot be empty";

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password confirmation from users in the Sign Up page.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }
                if (String.IsNullOrEmpty(value) || value != this.Password)
                    ValidationError = "password do not match";

                this.confirmPassword = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            throw new Exception("LoginClicked");
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            try
            {
                this.Name = "Sufiyan";
                this.Password = "aaa";
                this.ConfirmPassword = this.Password;
                this.Email = "sufiyany2k@hotmail.com";
                if (!ValidateFields())
                    return;
                
                RemoteServices rs = new RemoteServices();
                var newUser=rs.CreateUser(new User
                {
                    AuthenticationId = null, AuthenticationTypeId = 1,DisplayPicture = null, FirstName = Name,Id= null,IsActive = true, IsVerified = true, LastName = Name,
                    LoginId = Email, Password = this.Password,RegisteredDateTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new Exception("SignUpClicked");
            // Do something
        }

        private bool ValidateFields()
        {
            StringBuilder sb = new StringBuilder();
            
            if(String.IsNullOrEmpty(Name) || Name.Length<3)
                sb.AppendLine("Please enter a valid name");
            if(IsInvalidEmail)
                sb.AppendLine("Invalid Email");
            if(Password != ConfirmPassword)
                sb.AppendLine("Password do not match");

            ValidationError = sb.ToString();
            if (sb.Length > 0)
                return false;
            else
            {
                return true;
            }
        }

        #endregion
    }
}