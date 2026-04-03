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
            _connection = new SQLiteAsyncConnection(FileSystem.AppDataDirectory + "testDb.db3");
            _connection.CreateTableAsync<Entry>();
        }
        public async Task<List<Entry>> GetEntries()
        {
            return await _connection.Table<Entry>().ToListAsync();
        }
        public async Task CreateEntry(Entry entry)
        {
            await _connection.InsertAsync(entry);
        }
    }
}
