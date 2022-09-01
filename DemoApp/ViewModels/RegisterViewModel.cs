// -----------------------------------------------------------------------
//  <copyright file="RegisterViewModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.Views;
using System.Windows.Input;

namespace DemoApp.ViewModels
{
    internal class RegisterViewModel : BaseViewModel
    {
        private string emailId;

        /// <summary>
        ///  Gets or sets EmailId
        /// </summary>
        public string EmailId
        {
            get { return emailId; }
            set { SetProperty(ref emailId, value); }
        }

        private string password;

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string confirmPassword;

        /// <summary>
        ///  Gets or sets ConfirmPassword
        /// </summary>
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

        private bool isErrorVisible;

        /// <summary>
        /// Gets or sets IsErrorVisible
        /// </summary>
        public bool IsErrorVisible
        {
            get { return isErrorVisible; }
            set { SetProperty(ref isErrorVisible, value); }
        }

        private string errorMsg;

        /// <summary>
        /// Gets or sets ErrorMsg
        /// </summary>
        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetProperty(ref errorMsg, value); }
        }

        /// <summary>
        /// Register command action
        /// </summary>
        private Action OnRegisterCommand => async () => await RegisterUser();

        /// <summary>
        /// Register command
        /// </summary>
        public ICommand RegisterCommand { get; }

        /// <summary>
        /// RegisterViewModel Constructor
        /// </summary>
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterCommand);
        }

        /// <summary>
        /// Registers user
        /// </summary>
        private async Task RegisterUser()
        {
            IsErrorVisible = true;
            ErrorMsg = string.Empty;
            if (!string.IsNullOrEmpty(EmailId) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword))
            {
                if (Password.Equals(ConfirmPassword))
                {
                    //todo db operations
                    await Shell.Current.Navigation.PushAsync(new TestListPage());
                }
                else
                {
                    IsErrorVisible = true;
                    ErrorMsg = "Password and Confirm Password must be same";
                }
            }
            else
            {
                IsErrorVisible = true;
                ErrorMsg = "Fields can not be empty";
            }
        }
    }
}
