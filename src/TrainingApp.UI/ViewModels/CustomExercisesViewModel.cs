using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainingApp.Application.Entities.Workout;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

public partial class CustomExercisesViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ObservableCollection<Excercise> Excercises { get; set; }

    [ObservableProperty]
    bool isRefreshing;

    public event PropertyChangedEventHandler PropertyChanged;

    public AsyncCommand AddCommand { get; }

    public AsyncCommand RefreshCommand { get; }

    public CustomExercisesViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        var excercises = _applicationDbContext.Excercises.Where(x => !x.IsBuiltIn).ToList();
        Excercises = new ObservableCollection<Excercise>(excercises);

        OnPropertyChanged(nameof(Excercises));

        AddCommand = new AsyncCommand(Add);
        RefreshCommand = new AsyncCommand(Refresh);
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async Task Add()
    {
        await Shell.Current.GoToAsync(nameof(AddCustomExcercisePage));
    }

    private async Task Refresh()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        IsRefreshing = true;

        var excercises = await _applicationDbContext.Excercises.Where(x => !x.IsBuiltIn).ToListAsync();
        Excercises = new ObservableCollection<Excercise>(excercises);

        OnPropertyChanged(nameof(Excercises));

        IsBusy = false;
        IsRefreshing = false;
    }
}