using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            this._gradeRepository = gradeRepository;
        }

        public async Task<List<Grade>> GetAllActiveGradesAsListAsync()
        {
            return (await this._gradeRepository.GetAllActiveGradesAsync()).ToList();
        }

        public async Task<Grade?> GetGradeByIdAsync(int searchedGradeId)
        {
            return await this._gradeRepository.GetGradeByIdAsync(searchedGradeId);
        }

        public async Task<List<Grade>> GetFirstNPassingActiveGradesAsync(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("N must be a positive integer.");
            }

            var allGrades = await _gradeRepository.GetAllActiveGradesAsync();

            return allGrades
                .Where(grade => grade.IsActive && grade.IsPassing())
                .OrderByDescending(grade => grade.Value)
                .Take(n)
                .ToList();
        }
    }
}
