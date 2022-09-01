// -----------------------------------------------------------------------
//  <copyright file="QuestionsPage.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using DemoApp.ViewModels;

namespace DemoApp.Views;

public partial class QuestionsPage : ContentPage
{
    /// <summary>
    /// QuestionsPage Constructor
    /// </summary>
    public QuestionsPage()
	{
		InitializeComponent();
		BindingContext = new QuestionsViewModel();
	}
}