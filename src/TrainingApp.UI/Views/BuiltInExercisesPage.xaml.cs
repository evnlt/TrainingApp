using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class BuiltInExercisesPage : ContentPage
{
	private BuiltInExercisesViewModel vm;
	public BuiltInExercisesPage(BuiltInExercisesViewModel viewModel)
	{
		vm = viewModel;

		InitializeComponent();
        BindingContext = vm;
    }
}