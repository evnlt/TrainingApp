using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class RoutinesPage : ContentPage
{
    private RoutinesViewModel vm;
    public RoutinesPage(RoutinesViewModel viewModel)
	{
        vm = viewModel;

		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.RefreshCommand.ExecuteAsync();
    }
}