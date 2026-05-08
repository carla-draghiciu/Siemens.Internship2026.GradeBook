using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class GradeStatisticsService : IGradeStatisticsService
    {
        private readonly IGradeReader _gradeReader;

        public GradeStatisticsService(IGradeReader gradeReader)
        {
            _gradeReader = gradeReader;
        }

        public async Task<List<Grade>> GetAllGradesAsList()
        {
            return (await this._gradeReader.GetAllGradesAsync()).ToList();
        }

        public async Task<Grade?> GetGradeById(int searchedGradeId)
        {
            return await _gradeReader.GetGradeByIdAsync(searchedGradeId);
        }

        public async Task<object> ComputeGradeStatistics()
        {
            var allGrades = await this.GetAllGradesAsList();

            return new
            {
                TotalCount = allGrades.Count,
                AverageValue = allGrades.Any() ? allGrades.Average(grade => grade.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
