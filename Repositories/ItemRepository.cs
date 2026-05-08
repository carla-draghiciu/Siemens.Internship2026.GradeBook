using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public sealed class ItemRepository : IItemRepository
{
    private readonly List<Item> _items = new();
    private int _nextId = 1;

    public ItemRepository()
    {
        var i1 = new Item(10);
        var i2 = new Item(20);

        AddAsync(i1);
        AddAsync(i2);
    }

    public Task<Item?> GetByIdAsync(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id && i.IsActive);
        return Task.FromResult(item);
    }

    public Task<IEnumerable<Item>> GetAllAsync()
    {
        var items = _items.Where(i => i.IsActive).AsEnumerable();
        return Task.FromResult(items);
    }

    public Task AddAsync(Item item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return Task.CompletedTask;
    }

    private Item? FindItemById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var item = FindItemById(id);
        if (item == null) return Task.FromResult(false);
        _items.Remove(item);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateAsync(int id, Item item)
    {
        var foundItem = FindItemById(id);
        if (foundItem == null) return Task.FromResult(false);

        foundItem.Value = item.Value;
        return Task.FromResult(true);
    }
}