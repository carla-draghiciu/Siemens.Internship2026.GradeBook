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

        public async Task<List<Grade>> GetAllAsList()
        {
            return (await this._gradeReader.GetAllAsync()).ToList();
        }

        public async Task<Grade?> GetById(int searchedGradeId)
        {
            return await _gradeReader.GetByIdAsync(searchedGradeId);
        }

        public async Task<object> ComputeStatistics()
        {
            var allGrades = await this.GetAllAsList();

            return new
            {
                TotalCount = allGrades.Count,
                AverageValue = allGrades.Any() ? allGrades.Average(grade => grade.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
