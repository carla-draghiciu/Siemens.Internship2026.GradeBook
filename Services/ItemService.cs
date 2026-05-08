using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<object> ComputeStatistics()
        {
            var items = (await this._itemRepository.GetAllAsync()).ToList();

            return new
            {
                TotalCount = items.Count,
                AverageValue = items.Any() ? items.Average(i => i.Value) : 0,
                RetrievedAt = DateTime.UtcNow
            };
        }
    }
}
