using BL.Model;
using BL.Services;

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
            Task.Run(async () => goalsCollection.ItemsSource = await _db.GetAllGoalsDto());
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
                goalsCollection.ItemsSource = await  _db.GetAllGoalsDto();
            }
            else
            {
                await DisplayAlertAsync("Error", "Can't parse end date", "Close");
            }
        }
    }
}
