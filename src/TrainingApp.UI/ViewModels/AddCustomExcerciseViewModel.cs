using MvvmHelpers.Commands;
using System.Xml.Linq;
using TrainingApp.Application.Entities;
using TrainingApp.Application.Enums;
using TrainingApp.Infrastructure;
using TrainingApp.UI.Views;

namespace TrainingApp.UI.ViewModels;

public class AddCustomExcerciseViewModel : BaseViewModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    private string _name;

    public string Name { get => _name; set => SetProperty(ref _name, value); }

    private string _selectedType;

    public string SelectedType { get => _selectedType; set => SetProperty(ref _selectedType, value); }

    public AsyncCommand SaveCommand { get; }

    public AddCustomExcerciseViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        SaveCommand = new AsyncCommand(Save);

        _name = $"Custom {_applicationDbContext.Excercises.Where(x => !x.IsBuiltIn).Count() + 1}";
    }

    async Task Save()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return;
        }

        _applicationDbContext.Excercises
            .Add(new Excercise
            {
                Name = _name,
                IsBuiltIn = false,
                ExcersiceType = _selectedType == "Weight" ? ExcersiceType.Weight : ExcersiceType.Time
            }) ;

        await _applicationDbContext.SaveChangesAsync();

        await Shell.Current.GoToAsync($"//ExcersicesList/Kinds/Custom");
    }
}
