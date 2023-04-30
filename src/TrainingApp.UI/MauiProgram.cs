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
            return new ApplicationDbContext(Path.Combine(FileSystem.AppDataDirectory, "SQLite002.db3"));
        });

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<BuiltInExercisesViewModel>();
        builder.Services.AddSingleton<BuiltInExercisesPage>();

        builder.Services.AddSingleton<CustomExercisesViewModel>();
        builder.Services.AddSingleton<CustomExercisesPage>();

        return builder.Build();
    }
}
