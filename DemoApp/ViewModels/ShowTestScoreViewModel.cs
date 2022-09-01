// -----------------------------------------------------------------------
//  <copyright file="ShowTestScoreViewModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.Views;
using System.Windows.Input;

namespace DemoApp.ViewModels
{
    internal class ShowTestScoreViewModel : BaseViewModel
    {
        private string score;

        /// <summary>
        ///  Gets or sets Score
        /// </summary>
        public string Score
        {
            get { return score; }
            set { SetProperty(ref score, value); }
        }

        /// <summary>
        /// Redirect To Test command
        /// </summary>
        public ICommand RedirectToTestCommand { get; }

        /// <summary>
        /// ShowTestScoreViewModel Constructor
        /// </summary>
        public ShowTestScoreViewModel(int testScore)
        {
            Score = testScore.ToString();
            RedirectToTestCommand = new Command(ShowTestList);
        }

        /// <summary>
        /// Redirect to test list page
        /// </summary>
        private async void ShowTestList()
        {
            await Shell.Current.Navigation.PushAsync(new TestListPage());
        }
    }
}
