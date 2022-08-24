// -----------------------------------------------------------------------
//  <copyright file="BaseContentPage.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DemoApp.Helpers
{
    internal class BaseContentPage : ContentPage
    {
        /// <summary>
        /// Override Enable Back Button
        /// </summary>
        public static readonly BindableProperty EnableBackButtonOverrideProperty =
               BindableProperty.Create(
               nameof(EnableBackButtonOverride),
               typeof(bool),
               typeof(BaseContentPage),
               false);

        /// <summary>
        /// Gets or Sets Custom Back button overriding state
        /// </summary>
        public bool EnableBackButtonOverride
        {
            get
            {
                return (bool)GetValue(EnableBackButtonOverrideProperty);
            }
            set
            {
                SetValue(EnableBackButtonOverrideProperty, value);
            }
        }
    }
}
