using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeStatisticsService
    {
        Task<List<Grade>> GetAllGradesAsList();
        Task<Grade?> GetGradeById(int searchedGradeId);
        Task<object> ComputeGradeStatistics();
    }
}
