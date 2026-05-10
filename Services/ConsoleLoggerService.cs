using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Services
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void LogInfo(string messageToLog) 
        {
            Console.WriteLine($"[LOG] {DateTime.UtcNow}: {messageToLog}");
        }
    }
}
