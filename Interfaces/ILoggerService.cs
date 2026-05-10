namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string messageToLog);
        void LogError(string errorMessageToLog);
    }
}
