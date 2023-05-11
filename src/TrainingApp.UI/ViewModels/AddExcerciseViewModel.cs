using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(Routine), "Routine")]
public partial class AddExcerciseViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    Routine routine;

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

                var r = _applicationDbContext.Routines
                    .Where(x => x.Id == Routine.Id)
                    .Include(w => w.RoutineExcersices)
                    .FirstOrDefault();

                var exs = r.RoutineExcersices.Select(x => x.Excercise).ToList();

                var isBuildIn = _selectedType == "BuiltIn" ? true : false;
                var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn == isBuildIn).ToList();

                excercises = excercises.Where(x => !exs.Any(e => excercises.Contains(e) )).ToList();

                Excercises = new ObservableCollection<Excercise>(excercises);
                OnPropertyChanged(nameof(Excercises)); 
            }
        }
    }

    public void Load()
    {
        var r = _applicationDbContext.Routines
            .Where(x => x.Id == Routine.Id)
            .Include(w => w.RoutineExcersices)
            .FirstOrDefault();

        var exs = r.RoutineExcersices.Select(x => x.Excercise).ToList();

        var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn).ToList();

        excercises = excercises.Where(x => !exs.Any(e => excercises.Contains(e))).ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    public AddExcerciseViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn).ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    private async Task Add()
    {
        await Shell.Current.GoToAsync(nameof(EditRoutinePage), true, new Dictionary<string, object>
        {
            {"Routine", Routine }
        });
    }

    [RelayCommand]
    async Task AddExcercise(Excercise excercise)
    {
        if (excercise == null)
            return;

        var r = _applicationDbContext.Routines
            .Where(x => x.Id == Routine.Id)
            //.Include(w => w.RoutineExcersices)
            .FirstOrDefault();

        r.RoutineExcersices.Add(new RoutineExcersices
        {
            RoutineId = Routine.Id,
            Routine = Routine,
            ExcerciseId = excercise.Id,
            Excercise = excercise,
            Order = r.RoutineExcersices.Count
        });

        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync(nameof(EditRoutinePage), true, new Dictionary<string, object>
        {
            {"Routine", routine }
        });
    }
}
