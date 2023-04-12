using Microsoft.Extensions.Logging;
using TrainingApp.Infrastructure;

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

        return builder.Build();
    }
}
