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

        public async Task<object> ComputeGradeStatisticsAsync()
        {
            var allGrades = (await this._gradeReader.GetAllActiveGradesAsync()).ToList();

            return new
            {
                TotalCount = allGrades.Count,
                AverageValue = allGrades.Any() ? allGrades.Average(grade => grade.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
