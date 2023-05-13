using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class AddWorkoutPage : ContentPage
{
	public AddWorkoutPage(AddWorkoutViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
	}
}