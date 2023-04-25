namespace TrainingApp.UI;

public partial class App : Microsoft.Maui.Controls.Application
{
    public static IServiceProvider Services { get; protected set; }

    public App(IServiceProvider services)
	{
		InitializeComponent();

        Services = services;

        MainPage = new AppShell();
	}
}
