using MvvmHelpers;
using app_myconference.Models;
using CommunityToolkit.Mvvm.Input;
using Jeffsum;

namespace app_myconference.ViewModels
{
    public partial class ScheduleViewModel:ObservableObject
    {
        public int Day { get; set; }
        Random random = new();
        public ObservableRangeCollection<Grouping<string, Session>> Schedule { get; } = new();

        public ScheduleViewModel()
        {

        }

        [RelayCommand]
        Task LoadDataAsync()
        {
            var sessionCount = new[] { 1, 2, 4, 4, 4, 4 };
            var sessions = new List<Session>();
            var start = new DateTime(2022, 10, Day, 8, 30, 0);
            for (int i = 0; i < sessionCount.Length; i++)
                addItems(sessionCount[i],i);

            var sorted = from session in sessions
                         orderby session.Start
                         group session by session.StartTimeDisplay into sessionGroup
                         select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);

            Schedule.AddRange(sorted);

            return Task.CompletedTask;

            void addItems(int count,int offset)
            {
                for(int i = 0; i < count; i++)
                {
                    sessions.Add(new Session
                    {
                        Title = string.Join(" ",Jeffsum.Goldblum.ReceiveTheJeff(random.Next(2, 5), JeffsumType.Words)),
                        Description = Jeffsum.Goldblum.ReceiveTheJeff(1).First(),
                        Room = "Goldblum",
                        Start = start.AddHours(offset),
                        End = start.AddHours(offset+1)
                    });
                }
            }
        }
    }
}
