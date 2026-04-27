namespace BL.Model
{
    public class GoalDto : Goal
    {
        public double Progress { get; set; }
        public int ProgressPercentage { get => (int)(Progress * 100); set; }
        public bool IsDone { get => (ProgressPercentage == 100); set; }
        public int DaysAfterStart { get; set; }
        public int DaysLeftToEnd { get; set; }
    }
}
