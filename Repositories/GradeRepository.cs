using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public sealed class GradeRepository : IGradeRepository
{
    private readonly List<Grade> _items = new();
    private int _nextId = 1;

    public GradeRepository()
    {
        var i1 = new Grade(10);
        var i2 = new Grade(20);

        AddAsync(i1);
        AddAsync(i2);
    }

    public Task<Grade?> GetByIdAsync(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id && i.IsActive);
        return Task.FromResult(item);
    }

    public Task<IEnumerable<Grade>> GetAllAsync()
    {
        var items = _items.Where(i => i.IsActive).AsEnumerable();
        return Task.FromResult(items);
    }

    public Task AddAsync(Grade item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return Task.CompletedTask;
    }

    private Grade? FindItemById(int id)
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

    public Task<bool> UpdateAsync(int id, Grade item)
    {
        var foundItem = FindItemById(id);
        if (foundItem == null) return Task.FromResult(false);

        foundItem.Value = item.Value;
        return Task.FromResult(true);
    }
}