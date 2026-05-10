using Siemens.Internship2026.GradeBook.Constants;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories
{
    public class GradeAPIRepository : IGradeRepository
    {
        private const string SeedDataUrl = SeedData.url;

        private readonly List<Grade> _grades = new();
        private int _nextGradeId = GradeConstants.firstAvailableGradeId;

        private static readonly HttpClient _httpClient = new();

        private sealed record GradesEnvelope(List<Grade> Items);

        public GradeAPIRepository()
        {
            InitializeFromRemoteAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeFromRemoteAsync()
        {
            try
            {
                var envelope = await _httpClient
                    .GetFromJsonAsync<GradesEnvelope>(SeedDataUrl)
                    .ConfigureAwait(false);

                var seedGrades = envelope?.Items;

                if (seedGrades is null || seedGrades.Count == 0)
                {
                    return;
                }

                foreach (var grade in seedGrades)
                {
                    if (grade.Id <= GradeConstants.invalidGradeIdMargin)
                    {
                        grade.Id = _nextGradeId++;
                    }
                    else if (grade.Id >= _nextGradeId)
                    {
                        _nextGradeId = grade.Id + GradeConstants.gradeIdStep;
                    }

                    _grades.Add(grade);
                }
            }
            catch (HttpRequestException thrownException)
            {
                Console.Error.WriteLine($"[GradeRepository] Failed to seed from remote: {thrownException.Message}");
            }
        }

        public Task<Grade?> GetGradeByIdAsync(int searchedGradeId)
        {
            var foundGrade = _grades.FirstOrDefault(grade => grade.Id == searchedGradeId && grade.IsActive);
            return Task.FromResult(foundGrade);
        }

        public Task<IEnumerable<Grade>> GetAllActiveGradesAsync()
        {
            var allActiveGrades = _grades.Where(grade => grade.IsActive).AsEnumerable();
            return Task.FromResult(allActiveGrades);
        }

        public Task AddGradeAsync(Grade gradeToBeAdded)
        {
            gradeToBeAdded.Id = _nextGradeId++;
            _grades.Add(gradeToBeAdded);
            return Task.CompletedTask;
        }

        private Grade? FindGradeById(int searchedId)
        {
            return _grades.FirstOrDefault(grade => grade.Id == searchedId);
        }

        public Task<bool> UpdateGradeAsync(int idOfGradeToUpdate, Grade updatedGrade)
        {
            var foundItem = FindGradeById(idOfGradeToUpdate);
            if (foundItem == null)
            {
                return Task.FromResult(false);
            }

            foundItem.Value = updatedGrade.Value;
            foundItem.IsActive = updatedGrade.IsActive;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteGradeAsync(int idOfGradeToDelete)
        {
            var foundGrade = FindGradeById(idOfGradeToDelete);
            if (foundGrade == null)
            {
                return Task.FromResult(false);
            }

            _grades.Remove(foundGrade);
            return Task.FromResult(true);
        }
    }
}
