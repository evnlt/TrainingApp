using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

[QueryProperty(nameof(Routine), "Routine")]
public partial class EditRoutineViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    [ObservableProperty]
    Routine routine;

    public ObservableCollection<Excercise> Excercises { get; set; }

    public AsyncCommand AddCommand { get; }

    public AsyncCommand RefreshCommand { get; }

    public EditRoutineViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        AddCommand = new AsyncCommand(Add);
        RefreshCommand = new AsyncCommand(Refresh);
    }

    public void Load()
    {
        var excercises = _applicationDbContext.RoutineExcersices
            .Where(x => x.RoutineId == Routine.Id)
            .OrderBy(x => x.Order)
            .Select(x => x.Excercise)
            .ToList();

        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    [RelayCommand]
    private async Task DeleteExcercise(Excercise excercise)
    {
        if (excercise == null)
            return;

        var r = _applicationDbContext.Routines
            .Where(x => x.Id == Routine.Id)
            .Include(x => x.RoutineExcersices)
            .FirstOrDefault();

        var ex = r.RoutineExcersices.Where(x => x.Excercise == excercise).FirstOrDefault();

        _applicationDbContext.RoutineExcersices.Remove(ex);
        await _applicationDbContext.SaveChangesAsync();

        Excercises.Remove(excercise);
        await Refresh();
    }

    private async Task Add()
    {
        await Shell.Current.GoToAsync(nameof(AddExcercisePage), true, new Dictionary<string, object>
        {
            {"Routine", Routine }
        });
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

            var r = _applicationDbContext.Routines
                .Where(x => x.Id == Routine.Id)
                .Include(x => x.RoutineExcersices)
                .FirstOrDefault();

            var re = r.RoutineExcersices;

            int count = 1;
            foreach (var e in Excercises)
            {
                re.Where(x => x.ExcerciseId ==  e.Id).FirstOrDefault().Order = count++;
            }

            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}


