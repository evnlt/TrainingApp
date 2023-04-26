using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TrainingApp.Application.Entities.Workout;
using TrainingApp.Infrastructure;

namespace TrainingApp.UI.ViewModels;

public partial class HomeViewModel : BaseViewModel, INotifyPropertyChanged
{
    private DateTime _selectedDate;

    public ObservableCollection<Workout> Workouts { get; set; }

    private readonly ApplicationDbContext _applicationDbContext;

    public event PropertyChangedEventHandler PropertyChanged;

    public DateTime SelectedDate
    {
        get { return _selectedDate; }
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));

                var workouts = _applicationDbContext.Workouts
                    .Where(w => w.Date.Date == _selectedDate.Date)
                    .ToList();

                Workouts = new ObservableCollection<Workout>(workouts);
                OnPropertyChanged(nameof(Workouts));
            }
        }
    }

    public HomeViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        Title = "Home";
        SelectedDate = DateTime.Today;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
