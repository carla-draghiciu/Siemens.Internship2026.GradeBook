using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class ItemService : IItemService
    {
        public object ComputeStatistics(List<Item> items)
        {
            return new
            {
                TotalCount = items.Count,
                AverageValue = items.Any() ? items.Average(i => i.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
