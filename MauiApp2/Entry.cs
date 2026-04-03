
using SQLite;

namespace MauiApp2
{
    public class Entry
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
