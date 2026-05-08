using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IItemReader _itemReader;

        public StatisticsService(IItemReader itemReader)
        {
            _itemReader = itemReader;
        }

        public async Task<List<Item>> GetAllAsList()
        {
            return (await this._itemReader.GetAllAsync()).ToList();
        }

        public async Task<Item?> GetById(int id)
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
