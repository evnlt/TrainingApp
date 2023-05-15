using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(Workout), "Workout")]
public partial class AddExcerciseToWorkoutViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    Workout workout;

    public ObservableCollection<Excercise> Excercises { get; set; }

    private string _selectedType;
    public string SelectedType
    {
        get { return _selectedType; }
        set
        {
            if (_selectedType != value)
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));

                var w = _applicationDbContext.Workouts
                    .Where(x => x.Id == Workout.Id)
                    .Include(x => x.WorkoutExcersices)
                    .FirstOrDefault();

                var exs = w.WorkoutExcersices.Select(x => x.Excercise).ToList();

                var isBuildIn = _selectedType == "BuiltIn" ? true : false;
                var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn == isBuildIn).ToList();

                excercises = excercises.Where(x => !exs.Contains(x)).ToList();

                Excercises = new ObservableCollection<Excercise>(excercises);
                OnPropertyChanged(nameof(Excercises));
            }
        }
    }

    public void Load()
    {
        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == Workout.Id)
            .Include(w => w.WorkoutExcersices)
            .FirstOrDefault();

        var exs = w.WorkoutExcersices.Select(x => x.Excercise).ToList();

        var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn).ToList();

        excercises = excercises.Where(x => !exs.Contains(x)).ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    public AddExcerciseToWorkoutViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn).ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    private async Task Add()
    {
        await Shell.Current.GoToAsync(nameof(WorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", Workout }
        });
    }

    [RelayCommand]
    public async Task AddExcercise(Excercise excercise)
    {
        if (excercise == null)
            return;

        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == Workout.Id)
            //.Include(w => w.RoutineExcersices)
            .FirstOrDefault();

        var ex = _applicationDbContext.Excercises
            .Where(x => x.Id == excercise.Id)
            .FirstOrDefault();

        var we = new WorkoutExcersices
        {
            WorkoutId = w.Id,
            Workout = w,
            ExcerciseId = ex.Id,
            Excercise = ex,
            Order = w.WorkoutExcersices.Count + 1
        };
        _applicationDbContext.WorkoutExcersices.Add(we);

        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync(nameof(WorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", Workout }
        });
    }
}
