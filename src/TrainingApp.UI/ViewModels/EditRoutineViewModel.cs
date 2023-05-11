using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
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

        /*try
        {
            var r = _applicationDbContext.Routines
                        .Where(x => x.Id == routine.Id)
                        .Include(x => x.RoutineExcersices)
                        .FirstOrDefault();

            var excercises = r.RoutineExcersices
                .OrderBy(x => x.Order)
                .Select(x => x.Excercise)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }*/

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
}
