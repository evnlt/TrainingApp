using CommunityToolkit.Mvvm.ComponentModel;
using MvvmHelpers.Commands;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(DateTime), "DateTime")]
public partial class AddWorkoutViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    DateTime dateTime;

    private string _name;

    public string Name { get => _name; set => SetProperty(ref _name, value); }

    public AsyncCommand SaveCommand { get; }

    public AddWorkoutViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        SaveCommand = new AsyncCommand(Save);

        _name = $"Workout {_applicationDbContext.Workouts.Count() + 1}";
    }

    async Task Save()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return;
        }

        var workout = new Workout
        {
            Name = _name,
            Date = DateTime
        };

        _applicationDbContext.Workouts.Add(workout);

        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync(nameof(WorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", workout }
        });
    }
}
