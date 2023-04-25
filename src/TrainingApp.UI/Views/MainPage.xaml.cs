using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class MainPage : ContentPage
{
    public MainPage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

