namespace BL.Services
{
    public interface IProgressService
    {
        double CalculateProgress(DateTime start, DateTime end, DateTime? today = null);
    }
}