using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class SetPage : ContentPage
{
    private SetViewModel vm;

	public SetPage(SetViewModel viewModel)
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

    private void Measure_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Reps_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}