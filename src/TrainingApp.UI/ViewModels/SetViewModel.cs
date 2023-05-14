using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(WorkoutExcersices), "WorkoutExcersices")]
public partial class SetViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    WorkoutExcersices workoutExcersices;

    [ObservableProperty]
    string measureName;

    public ObservableCollection<Set> Sets { get; set; }

    public SetViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void Load()
    {
        Sets = new ObservableCollection<Set>(WorkoutExcersices.Sets.OrderBy(x => x.Order));
        OnPropertyChanged(nameof(Sets));

        if(WorkoutExcersices.Excercise.ExcersiceType == Application.Enums.ExcersiceType.Weight) 
        {
            MeasureName = "Kg";
        }
        else
        {
            MeasureName = "Sec";
        }

        OnPropertyChanged(MeasureName);
    }

    [RelayCommand]
    public async Task AddSet()
    {
        var newSet = new Set()
        {
            WorkoutId = WorkoutExcersices.WorkoutId,
            ExcerciseId = WorkoutExcersices.ExcerciseId,
            WorkoutExcercises = WorkoutExcersices,
        };
        var we = _applicationDbContext.WorkoutExcersices.Where(x => x.WorkoutId == WorkoutExcersices.WorkoutId).Include(x => x.Sets).FirstOrDefault();

        we.Sets.Add(newSet);

        var count = 1;
        foreach (var set in we.Sets)
        {
            set.Order = count++;
        }

        _applicationDbContext.WorkoutExcersices.Update(we);
        await _applicationDbContext.SaveChangesAsync();

        Sets.Add(newSet);
        OnPropertyChanged(nameof(Sets));
    }

    [RelayCommand]
    public async Task ChangeMeasure(Set set)
    {
        var s = _applicationDbContext.Sets.Where(x => x.Id == set.Id).FirstOrDefault();   

        s.Measure = set.Measure;
        await _applicationDbContext.SaveChangesAsync();
    }

    [RelayCommand]
    public async Task ChangeReps(Set set)
    {
        var s = _applicationDbContext.Sets.Where(x => x.Id == set.Id).FirstOrDefault();

        s.Reps = set.Reps;
        await _applicationDbContext.SaveChangesAsync();
    }
}
