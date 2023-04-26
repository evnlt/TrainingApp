﻿using TrainingApp.UI.ViewModels;

namespace TrainingApp.UI.Views;

public partial class MainPage : ContentPage
{
    private HomeViewModel vm;

    private DatePicker datePicker;

    public MainPage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        vm = viewModel;
        datePicker = (DatePicker)FindByName("DatePicker");
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        vm.SelectedDate = e.NewDate;
    }

    private void OnDayBeforeClicked(object sender, EventArgs e)
    {
        var selectedDate = datePicker.Date;
        var newDate = selectedDate.AddDays(-1);
        datePicker.Date = newDate;
    }

    private void OnDayAfterClicked(object sender, EventArgs e)
    {
        var selectedDate = datePicker.Date;
        var newDate = selectedDate.AddDays(1);
        datePicker.Date = newDate;
    }
}

