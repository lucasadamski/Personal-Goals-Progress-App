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
            await DisplayAlertAsync("Clicked", "Clicked the button add", "OK");
        }

        

    }
}
