using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeStatisticsService
    {
        Task<List<Grade>> GetAllAsList();
        Task<Grade?> GetById(int id);
        Task<object> ComputeStatistics();
    }
}
