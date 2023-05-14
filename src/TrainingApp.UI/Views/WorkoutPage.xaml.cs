using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class WorkoutPage : ContentPage
{
    private WorkoutViewModel vm;

    public WorkoutPage(WorkoutViewModel viewModel)
	{
        vm = viewModel;

		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.Load();
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        vm.ChangeIsDone(e.Value);
    }
}