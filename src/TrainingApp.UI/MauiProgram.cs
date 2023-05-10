using Microsoft.Extensions.Logging;
using TrainingApp.Infrastructure;
using TrainingApp.UI.ViewModels;
using TrainingApp.UI.Views;

namespace TrainingApp.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Logging.AddDebug();

        builder.Services.AddTransient((services) =>
        {
            return new ApplicationDbContext(Path.Combine(FileSystem.AppDataDirectory, "SQLite006.db3"));
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

        return builder.Build();
    }
}
