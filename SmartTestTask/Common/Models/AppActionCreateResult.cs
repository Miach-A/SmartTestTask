namespace SmartTestTask.Common.Models
{
    public class AppActionCreateResult : AppActionResult
    {
        public AppActionCreateResult(bool success, int id) : base(success)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
