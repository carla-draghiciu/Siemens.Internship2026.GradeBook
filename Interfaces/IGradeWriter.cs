using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeWriter
    {
        Task AddAsync(Grade gradeToBeAdded);
        Task<bool> DeleteAsync(int idOfGradeToDelete);
        Task<bool> UpdateAsync(int idOfGradeToUpdate, Grade newGrade);
    }
}
