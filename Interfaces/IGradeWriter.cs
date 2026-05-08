using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeWriter
    {
        Task AddAsync(Grade item);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, Grade item);
    }
}
