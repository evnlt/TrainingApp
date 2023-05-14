using Microsoft.Extensions.Logging;
using TrainingApp.Infrastructure;
using TrainingApp.UI.ViewModels;
using TrainingApp.UI.Views;
using C1.Maui;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;

namespace TrainingApp.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Logging.AddDebug();

        builder.Services.AddTransient((services) =>
        {
            return new ApplicationDbContext(Path.Combine(FileSystem.AppDataDirectory, "SQLite011.db3"));
        });

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<BuiltInExercisesViewModel>();
        builder.Services.AddTransient<BuiltInExercisesPage>();

        builder.Services.AddTransient<CustomExercisesViewModel>();
        builder.Services.AddTransient<CustomExercisesPage>();

        builder.Services.AddTransient<AddCustomExcerciseViewModel>();
        builder.Services.AddTransient<AddCustomExcercisePage>();

        builder.Services.AddTransient<WorkoutViewModel>();
        builder.Services.AddTransient<WorkoutPage>();

        builder.Services.AddTransient<RoutinesViewModel>();
        builder.Services.AddTransient<RoutinesPage>();

        builder.Services.AddTransient<AddRoutineViewModel>();
        builder.Services.AddTransient<AddRoutinePage>();

        builder.Services.AddTransient<EditRoutineViewModel>();
        builder.Services.AddTransient<EditRoutinePage>();

        builder.Services.AddTransient<AddExcerciseViewModel>();
        builder.Services.AddTransient<AddExcercisePage>();

        builder.Services.AddTransient<AddWorkoutViewModel>();
        builder.Services.AddTransient<AddWorkoutPage>();

        builder.Services.AddTransient<AddExcerciseToWorkoutViewModel>();
        builder.Services.AddTransient<AddExcerciseToWorkoutPage>();

        builder.Services.AddTransient<SetViewModel>();
        builder.Services.AddTransient<SetPage>();

        return builder.Build();
    }
}
