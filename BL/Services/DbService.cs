using BL.Model;
using SQLite;


namespace BL.Services
{
    public class DbService
    {
        public SQLiteAsyncConnection _connection { get; set; }
        public DbService(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
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
                EndOn = x.EndOn
            }).ToList();

            return result;
        }

        public async Task CreateEntry(Goal entry)
        {
            await _connection.InsertAsync(entry);
        }

     
    }
}
//