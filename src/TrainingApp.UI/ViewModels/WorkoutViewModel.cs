using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

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
        /*var w = _applicationDbContext.Workouts.Where(x => x.Id == Workout.Id).Include(x => x.WorkoutExcersices).FirstOrDefault();
        var excercises = new List<Excercise>();
        foreach (var item in w.WorkoutExcersices)
        {
            var ex = _applicationDbContext.Excercises.Where(x => x.Id == item.ExcerciseId).FirstOrDefault();
            excercises.Add(ex);
        }*/

        var excercises = _applicationDbContext.WorkoutExcersices
           .Where(x => x.WorkoutId == Workout.Id)
           .OrderBy(x => x.Order)
           .Select(x => x.Excercise)
           .ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }


    private bool _confirmation;

    public bool Confirmation
    {
        get => _confirmation;
        set => SetProperty(ref _confirmation, value);
    }

    [RelayCommand]
    public async Task Delete()
    {
        if (!Confirmation)
        {
            Confirmation = await App.Current.MainPage.DisplayAlert("Confirm Delete", "Are you sure you want to delete?", "Yes", "No");

            if (!Confirmation)
            {
                return;
            }
        }

        var w = _applicationDbContext.Workouts.Where(x => x.Id == Workout.Id).FirstOrDefault();
        _applicationDbContext.Workouts.Remove(w);
        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync("//MainPage");
    }

    [RelayCommand]
    public async Task AddExcercise()
    {
        await Shell.Current.GoToAsync(nameof(AddExcerciseToWorkoutPage), true, new Dictionary<string, object>
        {
            {"Workout", Workout }
        });
    }

    [RelayCommand]
    private async Task DeleteExcercise(Excercise excercise)
    {
        if (excercise == null)
            return;

        var r = _applicationDbContext.Workouts
            .Where(x => x.Id == Workout.Id)
            .Include(x => x.WorkoutExcersices)
            .FirstOrDefault();

        var ex = r.WorkoutExcersices.Where(x => x.Excercise == excercise).FirstOrDefault();

        _applicationDbContext.WorkoutExcersices.Remove(ex);
        await _applicationDbContext.SaveChangesAsync();

        Excercises.Remove(excercise);
        await Refresh();
    }

    private async Task Refresh()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        //IsRefreshing = true;

        /*var excercises = await _applicationDbContext.Excercises.Where(x => !x.IsBuiltIn).ToListAsync();
        Excercises = new ObservableCollection<Excercise>(excercises);*/

        OnPropertyChanged(nameof(Excercises));

        IsBusy = false;
        //IsRefreshing = false;
    }

    [RelayCommand]
    async Task GoToSet(Excercise excercise)
    {
        if (excercise == null)
            return;

        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == Workout.Id)
            .Include(w => w.WorkoutExcersices)
            .ThenInclude(x => x.Sets)
            .FirstOrDefault();

        var we = w.WorkoutExcersices.Where(x => x.ExcerciseId == excercise.Id).FirstOrDefault();

        await Shell.Current.GoToAsync(nameof(SetPage), true, new Dictionary<string, object>
        {
            {"WorkoutExcersices", we }
        });
    }

    public async Task ChangeIsDone(bool value)
    {
        var w = _applicationDbContext.Workouts
            .Where(x => x.Id == Workout.Id)
            .FirstOrDefault();

        w.IsDone = value;

        _applicationDbContext.Workouts.Update(w);
        await _applicationDbContext.SaveChangesAsync();

        Workout.IsDone = value;
    }






    private Excercise _itemBeingDragged;

    [RelayCommand]
    public void ItemDragged(Excercise ex)
    {
        _itemBeingDragged = ex;
    }

    [RelayCommand]
    public void ItemDragLeave(Excercise ex)
    {
    }

    [RelayCommand]
    public void ItemDraggedOver(Excercise ex)
    {
    }

    [RelayCommand]
    public async Task ItemDropped(Excercise excercise)
    {
        try
        {
            var itemToMove = _itemBeingDragged;
            var itemToInsertBefore = excercise;
            if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
                return;
            int insertAtIndex = Excercises.IndexOf(itemToInsertBefore);
            if (insertAtIndex >= 0 && insertAtIndex < Excercises.Count)
            {
                Excercises.Remove(itemToMove);
                Excercises.Insert(insertAtIndex, itemToMove);
                //itemToMove.IsBeingDragged = false;
                //itemToInsertBefore.IsBeingDraggedOver = false;
            }

            var w = _applicationDbContext.Workouts
                .Where(x => x.Id == Workout.Id)
                .Include(x => x.WorkoutExcersices)
                .FirstOrDefault();

            var we = w.WorkoutExcersices;

            int count = 1;
            foreach (var e in Excercises)
            {
                we.Where(x => x.ExcerciseId == e.Id).FirstOrDefault().Order = count++;
            }

            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
