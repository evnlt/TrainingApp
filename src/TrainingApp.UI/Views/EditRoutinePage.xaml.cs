using CommunityToolkit.Maui.Views;
using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class EditRoutinePage : ContentPage
{
	private EditRoutineViewModel vm;

    public EditRoutinePage(EditRoutineViewModel viewModel)
	{
		vm = viewModel;

		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await vm.RefreshCommand.ExecuteAsync();
		vm.Load();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupCalendarPage(vm.Routine));
    }
}