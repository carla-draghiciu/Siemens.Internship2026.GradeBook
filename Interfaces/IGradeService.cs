using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetAllActiveGradesAsList();
        Task<Grade?> GetGradeById(int searchedGradeId);
        Task<List<Grade>> GetFirstNPassingActiveGrades(int n);
    }
}
