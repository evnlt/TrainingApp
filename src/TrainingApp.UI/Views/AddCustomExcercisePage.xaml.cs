using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class AddCustomExcercisePage : ContentPage
{
	public AddCustomExcercisePage(AddCustomExcerciseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}