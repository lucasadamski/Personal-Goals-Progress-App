using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
        public async Task CreateEntry(Goal entry)
        {
            await _connection.InsertAsync(entry);
        }
    }
}
