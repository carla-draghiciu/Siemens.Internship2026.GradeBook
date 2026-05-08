using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public sealed class GradeRepository : IGradeRepository
{
    private readonly List<Grade> _grades = new();
    private int _nextGradeId = 1;

    public GradeRepository()
    {
        var i1 = new Grade(10);
        var i2 = new Grade(20);

        AddAsync(i1);
        AddAsync(i2);
    }

    public Task<Grade?> GetByIdAsync(int searchedGradeId)
    {
        var foundGrade = _grades.FirstOrDefault(grade => grade.Id == searchedGradeId && grade.IsActive);
        return Task.FromResult(foundGrade);
    }

    public Task<IEnumerable<Grade>> GetAllAsync()
    {
        var allActiveGrades = _grades.Where(grade => grade.IsActive).AsEnumerable();
        return Task.FromResult(allActiveGrades);
    }

    public Task AddAsync(Grade gradeToBeAdded)
    {
        gradeToBeAdded.Id = _nextGradeId++;
        _grades.Add(gradeToBeAdded);
        return Task.CompletedTask;
    }

    private Grade? FindItemById(int searchedId)
    {
        return _grades.FirstOrDefault(grade => grade.Id == searchedId);
    }

    public Task<bool> DeleteAsync(int idOfGradeToDelete)
    {
        var foundGrade = FindItemById(idOfGradeToDelete);
        if (foundGrade == null)
        {
            return Task.FromResult(false);
        }

        _grades.Remove(foundGrade);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateAsync(int idOfGradeToUpdate, Grade newGrade)
    {
        var foundItem = FindItemById(idOfGradeToUpdate);
        if (foundItem == null)
        {
            return Task.FromResult(false);
        }

        foundItem.Value = newGrade.Value;
        return Task.FromResult(true);
    }
}