using SQLite;
using System.Data.Common;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private DbService _db { get; set; }

        int count = 0;

        public MainPage(DbService db)
        {
            InitializeComponent();
            _db = db;
            Task.Run(async () => goalsCollection.ItemsSource = await _db.GetEntries());
        }


        async void OnDeleteGoalClicked(object? sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            await DisplayAlertAsync("Clicked", "Clicked the button delete ", "OK");
        }

        async void OnAddGoalClicked(object? sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if(DateTime.TryParse(goalEndDate.Text, out DateTime validEndTimeOfAGoal))
            {
                await DisplayAlertAsync("Success", "Created new goal. Good luck!", "Close");
                _db.CreateEntry(new Goal
                {
                    Title = goalName.Text,
                    StartOn = DateTime.Now,
                    EndOn = validEndTimeOfAGoal
                });
                Task.Run(async () => goalsCollection.ItemsSource = await _db.GetEntries());

            }
            else
            {
                await DisplayAlertAsync("Error", "Can't parse end date", "Close");
            }
        }

        private async Task<double> CalculateGoalProgress(DateTime start, DateTime end)
        {
            var result = 0.0D;
            if (start == null || end == null) return result;
            if (DateTime.Today > end) return 1.0D;
            if (start > end || DateTime.Today < start) return result;
            var todayProgress = start - DateTime.Now;
            var goalTime = end - start;
            result = goalTime / todayProgress;
            return result;
        }
    }
}
