namespace BL.Services
{
    public interface IProgressService
    {
        double CalculateProgress(DateTime start, DateTime end, DateTime? today = null);
        int CalculateDaysAfterStart(DateOnly start, DateOnly today);
        int CalculateDaysLeftToEnd(DateOnly end, DateOnly today);

    }
}