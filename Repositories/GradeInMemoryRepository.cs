using Siemens.Internship2026.GradeBook.Constants;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public sealed class GradeInMemoryRepository : IGradeRepository
{
    private readonly List<Grade> _grades = new();
    private int _nextGradeId = GradeConstants.firstAvailableGradeId;

    public Task<Grade?> GetGradeByIdAsync(int searchedGradeId)
    {
        var foundGrade = _grades.FirstOrDefault(grade => grade.Id == searchedGradeId && grade.IsActive);
        return Task.FromResult(foundGrade);
    }

    public Task<IEnumerable<Grade>> GetAllActiveGradesAsync()
    {
        var allActiveGrades = _grades.Where(grade => grade.IsActive).AsEnumerable();
        return Task.FromResult(allActiveGrades);
    }

    public Task AddGradeAsync(Grade gradeToBeAdded)
    {
        gradeToBeAdded.Id = _nextGradeId++;
        _grades.Add(gradeToBeAdded);
        return Task.CompletedTask;
    }

    private Grade? FindGradeById(int searchedId)
    {
        return _grades.FirstOrDefault(grade => grade.Id == searchedId);
    }

    public Task<bool> UpdateGradeAsync(int idOfGradeToUpdate, Grade updatedGrade)
    {
        var foundGrade = FindGradeById(idOfGradeToUpdate);
        if (foundGrade == null)
        {
            return Task.FromResult(false);
        }

        foundGrade.Value = updatedGrade.Value;
        foundGrade.IsActive = updatedGrade.IsActive;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteGradeAsync(int idOfGradeToDelete)
    {
        var foundGrade = FindGradeById(idOfGradeToDelete);
        if (foundGrade == null)
        {
            return Task.FromResult(false);
        }

        _grades.Remove(foundGrade);
        return Task.FromResult(true);
    }
}