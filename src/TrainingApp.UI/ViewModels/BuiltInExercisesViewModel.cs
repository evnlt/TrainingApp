using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainingApp.Application.Entities.Workout;
using TrainingApp.Infrastructure;

namespace TrainingApp.UI.ViewModels;

public class BuiltInExercisesViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ObservableCollection<Excercise> Excercises { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public BuiltInExercisesViewModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        var excercises = _applicationDbContext.Excercises.Where(x => x.IsBuiltIn ).ToList();
        Excercises = new ObservableCollection<Excercise>(excercises);
        OnPropertyChanged(nameof(Excercises));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
