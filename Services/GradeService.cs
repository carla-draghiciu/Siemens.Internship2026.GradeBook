using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            this._gradeRepository = gradeRepository;
        }

        public async Task<List<Grade>> GetAllGradesAsList()
        {
            return (await this._gradeRepository.GetAllGradesAsync()).ToList();
        }

        public async Task<Grade?> GetGradeById(int searchedGradeId)
        {
            return await this._gradeRepository.GetGradeByIdAsync(searchedGradeId);
        }
    }
}
