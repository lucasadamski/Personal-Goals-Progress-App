using System.Collections;

namespace BL.Services
{
    public class ProgressService : IProgressService
    {
        public double CalculateProgress(DateTime start, DateTime end, DateTime? today = null)
        {
            var result = 0.0D;
            if (start == null || end == null) return result;

            var todayDate = (today == null) ?
                    DateOnly.FromDateTime(DateTime.Today) :
                    DateOnly.FromDateTime((DateTime)today);
            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);
            if (IsStartLaterThanEnd(startDate, endDate)) return 0.0D;
            if (IsTodayBeforeStart(startDate, todayDate)) return 0.0D;
            if (IsTodayAfterEnd(endDate, todayDate)) return 1.0D;

            result = CalculateProgress(startDate, todayDate, endDate);

            return Math.Round(result, 2);
        }

        private bool IsTodayAfterEnd(DateOnly endDate, DateOnly todayDate)
        {
            if (todayDate.DayNumber > endDate.DayNumber) return true;
            return false;
        }

        private bool IsTodayBeforeStart(DateOnly startDate, DateOnly todayDate)
        {
            if (todayDate.DayNumber <= startDate.DayNumber) return true;
            return false;
        }

        private bool IsStartLaterThanEnd(DateOnly start, DateOnly end)
        {
            if (start > end) return true;
            return false;
        }

        private double CalculateProgress(DateOnly start, DateOnly today, DateOnly end)
        {
            var result = 0.0D;

            if (today.DayNumber == start.DayNumber) return 0.0D;
            var todayProgress = today.DayNumber - start.DayNumber;
            var goalTime = end.DayNumber - start.DayNumber;
            result = (double)todayProgress / (double)goalTime;
            return result;
        }

        public int CalculateDaysAfterStart(DateOnly start, DateOnly today)
        {
            if (start == null || today == null) return 0;
            if (start.DayNumber >= today.DayNumber) return 0;
            return today.DayNumber - start.DayNumber;
        }
        public int CalculateDaysLeftToEnd(DateOnly end, DateOnly today)
        {
            if (end == null || today == null) return 0;
            if (end.DayNumber <= today.DayNumber) return 0;
            return end.DayNumber - today.DayNumber;
        }
    }
}
