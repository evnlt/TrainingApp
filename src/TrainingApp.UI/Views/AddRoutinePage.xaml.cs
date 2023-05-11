using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class AddRoutinePage : ContentPage
{
	public AddRoutinePage(AddRoutineViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}