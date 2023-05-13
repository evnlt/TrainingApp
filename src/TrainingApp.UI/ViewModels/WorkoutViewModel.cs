using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(Workout), "Workout")]
public partial class WorkoutViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    Workout workout;

    public ObservableCollection<Excercise> Excercises { get; set; }

    public WorkoutViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void Load()
    {
        var w = _applicationDbContext.Workouts.Where(x => x.Id == Workout.Id).Include(x => x.WorkoutExcersices).FirstOrDefault();
        var excercises = new List<Excercise>();
        foreach (var item in w.WorkoutExcersices)
        {
            var ex = _applicationDbContext.Excercises.Where(x => x.Id == item.ExcerciseId).FirstOrDefault();
            excercises.Add(ex);
        }
        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }
}
