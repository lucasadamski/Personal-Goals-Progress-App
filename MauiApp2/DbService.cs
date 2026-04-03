using MauiApp2.Model;
using SQLite;
using System.Linq;

namespace MauiApp2
{
    public class DbService
    {
        public SQLiteAsyncConnection _connection { get; set; }
        public DbService()
        {
            _connection = new SQLiteAsyncConnection(FileSystem.AppDataDirectory + "GoalDatabase.db3");
            _connection.CreateTableAsync<Goal>();
        }
        public async Task<List<Goal>> GetEntries()
        {
            return await _connection.Table<Goal>().ToListAsync();
        }

        public async Task<List<GoalDto>> GetAllGoalsDto()
        {
            var goalsFromDb = await _connection.Table<Goal>().ToListAsync();
            var result = goalsFromDb.Select(x => new GoalDto
            {
                Id = x.Id,
                Title = x.Title,
                StartOn = x.StartOn,
                EndOn = x.EndOn,
                Progress = CalculateGoalProgress(x.StartOn, x.EndOn)
            }).ToList();

            return result;
        }

        public async Task CreateEntry(Goal entry)
        {
            await _connection.InsertAsync(entry);
        }

        private double CalculateGoalProgress(DateTime start, DateTime end)
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
//