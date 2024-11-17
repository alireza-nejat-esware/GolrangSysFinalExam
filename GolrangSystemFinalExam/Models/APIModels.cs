namespace GolrangSystemFinalExam.API.Models
{
    public class Result
    {
        public string Message { get; set; } = "";
        public object? Data { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Success = 1,
        Failed = -1,
    }
}
