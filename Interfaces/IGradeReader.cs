using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeReader
{
    Task<Grade?> GetGradeByIdAsync(int searchedGradeId);
    Task<IEnumerable<Grade>> GetAllGradesAsync();
}
