using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class AddExcercisePage : ContentPage
{
    private AddExcerciseViewModel vm;
    public AddExcercisePage(AddExcerciseViewModel viewModel)
	{
        vm = viewModel;

		InitializeComponent();
        BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        //await vm.RefreshCommand.ExecuteAsync();
        vm.Load();
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var val = (sender as RadioButton)?.Value as string;
        if (string.IsNullOrWhiteSpace(val))
            return;

        vm.SelectedType = val;
    }
}