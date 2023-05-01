using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainingApp.Application.Entities.Workout;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

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

        SelectedDate = DateTime.Today;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    [RelayCommand]
    async Task GoToWorkout(Workout workout)
    {
        if (workout == null)
            return;

        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == workout.Id)
            .Include(w => w.Workouts2Excersices)
            .FirstOrDefault();

        await Shell.Current.GoToAsync(nameof(WorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", w }
        });
    }
}
