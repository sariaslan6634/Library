namespace Library.WebAPI.Models
{
    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>>? Details { get; set; }
    }
}
