using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class AddCustomExcercisePage : ContentPage
{
    private AddCustomExcerciseViewModel vm;
    public AddCustomExcercisePage(AddCustomExcerciseViewModel viewModel)
	{
        vm = viewModel;
		
        InitializeComponent();
		BindingContext = viewModel;
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var val = (sender as RadioButton)?.Value as string;
        if (string.IsNullOrWhiteSpace(val))
            return;

        vm.SelectedType = val;
    }
}