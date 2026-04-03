using SQLite;

namespace MauiApp2
{
    public class Goal
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
    }
}
