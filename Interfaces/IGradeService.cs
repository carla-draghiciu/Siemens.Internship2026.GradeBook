using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetAllActiveGradesAsListAsync();
        Task<Grade?> GetGradeByIdAsync(int searchedGradeId);
        Task<List<Grade>> GetFirstNPassingActiveGradesAsync(int n);
    }
}
