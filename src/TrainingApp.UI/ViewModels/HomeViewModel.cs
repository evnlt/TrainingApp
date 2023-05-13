using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

public partial class HomeViewModel : BaseViewModel, INotifyPropertyChanged
{
    private DateTime _selectedDate;

    public ObservableCollection<Workout> Workouts { get; set; }

    public ObservableCollection<Routine> Routines { get; set; }

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

                var routines = _applicationDbContext.Routines.ToList();

                routines = routines.Where(x => x.DateTimes.Contains(_selectedDate)).ToList();

                Routines = new ObservableCollection<Routine>(routines);
                OnPropertyChanged(nameof(Routines));
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
            .Include(w => w.WorkoutExcersices)
            .FirstOrDefault();

        await Shell.Current.GoToAsync(nameof(WorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", w }
        });
    }

    [RelayCommand]
    async Task StartRoutine(Routine routine)
    {
        if (routine == null)
            return;

        var r = _applicationDbContext.Routines.Where(x => x.Id == routine.Id).Include(x => x.RoutineExcersices).FirstOrDefault();

        var newWorkout = new Workout {
            Date = _selectedDate,
            IsDone = false,
            Name = r.Name,
            WorkoutExcersices = new List<WorkoutExcersices>()
        };

        foreach (var item in r.RoutineExcersices.OrderBy(x => x.Order))
        {
            var ex = _applicationDbContext.Excercises.Where(x => x.Id == item.ExcerciseId).FirstOrDefault();
            var we = new WorkoutExcersices
            {
                ExcerciseId = ex.Id,
                Excercise = ex,
                WorkoutId = newWorkout.Id,
                Workout = newWorkout,
                Order = item.Order,
            };

            newWorkout.WorkoutExcersices.Add(we);
            _applicationDbContext.WorkoutExcersices.Add(we);
        }

        _applicationDbContext.Workouts.Add(newWorkout);
        await _applicationDbContext.SaveChangesAsync();

        r.DateTimes.Remove(_selectedDate);
        _applicationDbContext.Routines.Update(r);

        await _applicationDbContext.SaveChangesAsync();

        Routines.Remove(routine);
        Workouts.Add(newWorkout);
    }

    [RelayCommand]
    async Task AddWorkout()
    {

        await Shell.Current.GoToAsync(nameof(AddWorkoutPage), true, new Dictionary<string, object>
        {
            {"DateTime", SelectedDate }
        });
    }

    public async Task Refresh()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        //IsRefreshing = true;

        var workouts = _applicationDbContext.Workouts
                    .Where(w => w.Date.Date == _selectedDate.Date)
                    .ToList();

        Workouts = new ObservableCollection<Workout>(workouts);
        OnPropertyChanged(nameof(Workouts));

        var routines = _applicationDbContext.Routines.ToList();

        routines = routines.Where(x => x.DateTimes.Contains(_selectedDate)).ToList();

        Routines = new ObservableCollection<Routine>(routines);
        OnPropertyChanged(nameof(Routines));

        IsBusy = false;
        //IsRefreshing = false;
    }
}
