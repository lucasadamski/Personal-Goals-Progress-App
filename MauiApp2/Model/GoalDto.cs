

namespace MauiApp2.Model
{
    public class GoalDto : Goal
    {
        public double Progress { get => CalculateGoalProgress(StartOn, EndOn); set; }
        private double CalculateGoalProgress(DateTime start, DateTime end)
        {
            var result = 0.0D;
            if (start == null || end == null) return result;
            if (DateTime.Now > end) return 1.0D;
            if (start > end || DateTime.Now < start) return result;
            var todayProgress = DateTime.Now - start;
            var goalTime = end - start;
            result = todayProgress / goalTime;
            return result;  
        }
    }
}
