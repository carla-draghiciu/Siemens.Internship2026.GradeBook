using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IItemWriter
    {
        Task AddAsync(Item item);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, Item item);
    }
}
