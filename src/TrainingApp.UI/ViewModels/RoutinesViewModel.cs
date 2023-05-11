using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

public partial class RoutinesViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ObservableCollection<Routine> Routines { get; set; }

    [ObservableProperty]
    private bool isRefreshing;

    public event PropertyChangedEventHandler PropertyChanged;

    public AsyncCommand AddCommand { get; }

    public AsyncCommand RefreshCommand { get; }

    public RoutinesViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        var routines = _applicationDbContext.Routines.ToList();
        Routines = new ObservableCollection<Routine>(routines);

        OnPropertyChanged(nameof(Routines));

        AddCommand = new AsyncCommand(Add);
        RefreshCommand = new AsyncCommand(Refresh);
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async Task Add()
    {
        await Shell.Current.GoToAsync(nameof(AddRoutinePage));
    }

    private async Task Refresh()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        //IsRefreshing = true;

        var routines = await _applicationDbContext.Routines.ToListAsync();
        Routines = new ObservableCollection<Routine>(routines);

        OnPropertyChanged(nameof(Routines));

        IsBusy = false;
        //IsRefreshing = false;
    }

    [RelayCommand]
    async Task GoToRoutine(Routine routine)
    {
        if (routine == null)
            return;
        /*
        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == workout.Id)
            .Include(w => w.WorkoutExcersices)
            .FirstOrDefault();*/

        await Shell.Current.GoToAsync(nameof(EditRoutinePage), true, new Dictionary<string, object>
        {
            {"Routine", routine }
        });
    }
}