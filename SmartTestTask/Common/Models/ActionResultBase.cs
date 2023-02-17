namespace SmartTestTask.Common.Models
{
    public class ActionResultBase
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<String>();
    }
}
