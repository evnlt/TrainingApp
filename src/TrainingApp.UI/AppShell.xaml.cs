using TrainingApp.UI.Views;

namespace TrainingApp.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AddCustomExcercisePage), typeof(AddCustomExcercisePage));
        Routing.RegisterRoute(nameof(CustomExercisesPage), typeof(CustomExercisesPage));
        Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
    }
}
