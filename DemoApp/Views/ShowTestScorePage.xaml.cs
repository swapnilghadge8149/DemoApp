using DemoApp.ViewModels;

namespace DemoApp.Views;

public partial class ShowTestScorePage : ContentPage
{
	public ShowTestScorePage(int score)
	{
		InitializeComponent();
		BindingContext = new ShowTestScoreViewModel(score);
	}
}