using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers.Commands;
using TrainingApp.Application.Entities;
using TrainingApp.Application.Enums;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

public class AddRoutineViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    private string _name;

    public string Name { get => _name; set => SetProperty(ref _name, value); }

    public AsyncCommand SaveCommand { get; }

    public AddRoutineViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        SaveCommand = new AsyncCommand(Save);

        _name = $"Routine {_applicationDbContext.Routines.Count() + 1}";
    }

    async Task Save()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return;
        }

        var routine = new Routine
        {
            Name = _name,
        };

        _applicationDbContext.Routines
            .Add(routine);

        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync(nameof(EditRoutinePage), true, new Dictionary<string, object>
        {
            {"Routine", routine }
        });
    }
}
