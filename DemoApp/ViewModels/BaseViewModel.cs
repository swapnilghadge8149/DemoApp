// -----------------------------------------------------------------------
//  <copyright file="BaseViewModel.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.Helpers;

namespace DemoApp.ViewModels
{
    internal abstract class BaseViewModel : ObservableObject
    {
        private bool isBusy = false;

        /// <summary>
        ///  Gets or sets IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        /// <summary>
        ///  Gets or sets CurrentPage
        /// </summary>
        protected BaseContentPage CurrentPage { get; private set; }

        /// <summary>
        ///  BaseViewModel Constructor
        /// </summary>
        public BaseViewModel(BaseContentPage page = null)
        {
            if (page != null)
            {
                CurrentPage = page;
                CurrentPage.Appearing += CurrentPageOnAppearing;
                CurrentPage.Disappearing += CurrentPageOnDisappearing;
            }
        }

        /// <summary>
        /// On CurrentPage Appearing
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="eventArgs">eventArgs</param>
        protected virtual void CurrentPageOnAppearing(object sender, EventArgs eventArgs) { }

        /// <summary>
        /// On CurrentPage Disappearing
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="eventArgs">eventArgs</param>
        protected virtual void CurrentPageOnDisappearing(object sender, EventArgs eventArgs) { }
    }
}
