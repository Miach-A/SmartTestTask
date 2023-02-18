namespace SmartTestTask.Common.Models
{
    public class AppActionResult
    {
        public AppActionResult(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public bool AutoRepeatPossible { get; set; } = false;
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
