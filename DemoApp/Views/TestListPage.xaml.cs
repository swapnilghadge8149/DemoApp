// -----------------------------------------------------------------------
//  <copyright file="TestListPage.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.ViewModels;

namespace DemoApp.Views;

public partial class TestListPage : ContentPage
{
    /// <summary>
    /// TestListPage Constructor
    /// </summary>
    public TestListPage()
	{
		InitializeComponent();
		BindingContext = new TestListViewModel();
	}
}