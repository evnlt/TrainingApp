using CommunityToolkit.Maui.Views;
using Syncfusion.Maui.Calendar;
using TrainingApp.Application.Entities;
using TrainingApp.Infrastructure;
using System.Collections.ObjectModel;

namespace TrainingApp.UI.Views;

public partial class PopupCalendarPage : Popup
{
    private Routine _routine;
    private ApplicationDbContext _applicationDbContext;

    private bool _firstTime = true;

    public PopupCalendarPage(Routine routine)
    {
        InitializeComponent();

        _applicationDbContext = App.Services.GetService<ApplicationDbContext>();
        _routine = _applicationDbContext.Routines.Where(x => x.Id == routine.Id).FirstOrDefault();

        this.calendar.SelectedDates = new ObservableCollection<DateTime>(_routine.DateTimes);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void calendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
    {
        if (_firstTime)
        {
            _firstTime = false;
            return;
        }

        var newValue = (e.NewValue as ReadOnlyCollection<DateTime>).ToList();
        var oldValue = (e.OldValue as ReadOnlyCollection<DateTime>).ToList();

        // added
        if (newValue.Count > oldValue.Count)
        {
            var addedDate = newValue.Where(x => !oldValue.Contains(x)).FirstOrDefault();
            _routine.DateTimes.Add(addedDate);
            try 
            {
                _applicationDbContext.Routines.Update(_routine);
                _applicationDbContext.SaveChanges();
            }
            catch(Exception ex) 
            { 
            }
        }
        // removed
        else
        {
            var removedDate = oldValue.Where(x => !newValue.Contains(x)).FirstOrDefault();
            _routine.DateTimes.Remove(removedDate);
            try
            {
                _applicationDbContext.Routines.Update(_routine);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}