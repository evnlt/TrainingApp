using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class CustomExercisesPage : ContentPage
{
    private CustomExercisesViewModel vm;
    public CustomExercisesPage(CustomExercisesViewModel viewModel)
    {
        vm = viewModel;

        InitializeComponent();
        BindingContext = vm;
    }
}