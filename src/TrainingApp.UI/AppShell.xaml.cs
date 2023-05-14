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

        Routing.RegisterRoute(nameof(AddRoutinePage), typeof(AddRoutinePage));
        Routing.RegisterRoute(nameof(RoutinesPage), typeof(RoutinesPage));
        Routing.RegisterRoute(nameof(EditRoutinePage), typeof(EditRoutinePage));

        Routing.RegisterRoute(nameof(AddExcercisePage), typeof(AddExcercisePage));

        Routing.RegisterRoute(nameof(AddWorkoutPage), typeof(AddWorkoutPage));

        Routing.RegisterRoute(nameof(AddExcerciseToWorkoutPage), typeof(AddExcerciseToWorkoutPage));

        Routing.RegisterRoute(nameof(SetPage), typeof(SetPage));
    }
}
