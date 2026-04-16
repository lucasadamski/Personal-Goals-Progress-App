namespace BL.Model
{
    public class GoalDto : Goal
    {
        public double Progress { get; set; }
        public int ProgressPercentage { get; set; } // to do implement in ui 
    }
}
