using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CustomExercisesPage : ContentPage
{
    private CustomExercisesViewModel vm;
    public CustomExercisesPage(CustomExercisesViewModel viewModel)
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