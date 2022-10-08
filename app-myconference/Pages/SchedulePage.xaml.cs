using app_myconference.ViewModels;

namespace app_myconference.Pages;


public class ScheduleDay1Page : SchedulePage
{
	public ScheduleDay1Page(ScheduleViewModel vm) : base()
	{
		Title = "Day 1 Schedule";
		vm.Day = 1;
		BindingContext = vm;
	}
}

public class ScheduleDay2Page : SchedulePage
{
    public ScheduleDay2Page(ScheduleViewModel vm) : base()
    {
        Title = "Day 2 Schedule";
        vm.Day = 2;
        BindingContext = vm;
    }
}

public partial class SchedulePage : ContentPage
{
    ScheduleViewModel vm;
    public ScheduleViewModel VM => vm ??= BindingContext as ScheduleViewModel;
    public SchedulePage()
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		if(VM.Schedule.Count == 0)
			await vm.LoadDataCommand.ExecuteAsync(null);
	}
}