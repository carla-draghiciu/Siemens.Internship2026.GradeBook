using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class GradeStatisticsService : IGradeStatisticsService
    {
        private readonly IGradeReader _itemReader;

        public GradeStatisticsService(IGradeReader itemReader)
        {
            _itemReader = itemReader;
        }

        public async Task<List<Grade>> GetAllAsList()
        {
            return (await this._itemReader.GetAllAsync()).ToList();
        }

        public async Task<Grade?> GetById(int id)
        {
            return await _itemReader.GetByIdAsync(id);
        }

        public async Task<object> ComputeStatistics()
        {
            var items = await this.GetAllAsList();

            return new
            {
                TotalCount = items.Count,
                AverageValue = items.Any() ? items.Average(i => i.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
