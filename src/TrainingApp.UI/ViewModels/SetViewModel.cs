using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

    [RelayCommand]
    public async Task DeleteSet(Set set)
    {
        var s = _applicationDbContext.Sets.Where(x => x.Id == set.Id).FirstOrDefault();
        var we = _applicationDbContext.WorkoutExcersices.Where(x => x.WorkoutId == WorkoutExcersices.WorkoutId).Include(x => x.Sets).FirstOrDefault();

        we.Sets.Remove(s);
        _applicationDbContext.Sets.Remove(s);

        var count = 1;
        foreach (var item in we.Sets)
        {
            item.Order = count++;
        }

        _applicationDbContext.WorkoutExcersices.Update(we);
        await _applicationDbContext.SaveChangesAsync();

        Sets.Remove(set);
        OnPropertyChanged(nameof(Sets));
    }



    private Set _itemBeingDragged;

    [RelayCommand]
    public void ItemDragged(Set set)
    {
        _itemBeingDragged = set;
    }

    [RelayCommand]
    public void ItemDragLeave(Set set)
    {
    }

    [RelayCommand]
    public void ItemDraggedOver(Set set)
    {
    }

    [RelayCommand]
    public async Task ItemDropped(Set set)
    {
        try
        {
            var itemToMove = _itemBeingDragged;
            var itemToInsertBefore = set;
            if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
                return;
            int insertAtIndex = Sets.IndexOf(itemToInsertBefore);
            if (insertAtIndex >= 0 && insertAtIndex < Sets.Count)
            {
                Sets.Remove(itemToMove);
                Sets.Insert(insertAtIndex, itemToMove);
                //itemToMove.IsBeingDragged = false;
                //itemToInsertBefore.IsBeingDraggedOver = false;
            }

            int count = 1;
            foreach (var item in Sets)
            {
                item.Order = count++;
            }

            //var s = _applicationDbContext.Sets.Where(x => x.Id == set.Id).FirstOrDefault();
            var we = _applicationDbContext.WorkoutExcersices.Where(x => x.WorkoutId == WorkoutExcersices.WorkoutId).Include(x => x.Sets).FirstOrDefault();

            //var we = w.WorkoutExcersices;

            count = 1;
            foreach (var s1 in Sets)
            {
                we.Sets.Where(x => x.Id == s1.Id).FirstOrDefault().Order = count++;
            }

            _applicationDbContext.WorkoutExcersices.Update(we);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
