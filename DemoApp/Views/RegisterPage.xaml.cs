// -----------------------------------------------------------------------
//  <copyright file="RegisterPage.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.ViewModels;

namespace DemoApp.Views;

public partial class RegisterPage : ContentPage
{
    /// <summary>
    /// RegisterPage Constructor
    /// </summary>
    public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
	}
}


