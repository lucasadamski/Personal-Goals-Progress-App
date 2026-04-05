

namespace MauiApp2.Model
{
    public class GoalDto : Goal
    {
        public double Progress { get => CalculateGoalProgress(StartOn, EndOn); set; }

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
