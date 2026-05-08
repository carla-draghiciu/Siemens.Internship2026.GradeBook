using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IGradeWriter
    {
        Task AddGradeAsync(Grade gradeToBeAdded);
        Task<bool> DeleteGradeAsync(int idOfGradeToDelete);
        Task<bool> UpdateGradeAsync(int idOfGradeToUpdate, Grade newGrade);
    }
}
