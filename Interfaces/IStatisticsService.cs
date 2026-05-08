using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IStatisticsService
    {
        Task<List<Item>> GetAllAsList();
        Task<Item?> GetById(int id);
        Task<object> ComputeStatistics();
    }
}
