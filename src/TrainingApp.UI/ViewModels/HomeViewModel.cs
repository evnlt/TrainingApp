using CommunityToolkit.Mvvm.ComponentModel;

namespace TrainingApp.UI.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Today;

    public HomeViewModel()
    {
    }
}
