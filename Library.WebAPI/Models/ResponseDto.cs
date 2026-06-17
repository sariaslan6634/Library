namespace Library.WebAPI.Models
{
    public class ResponseDto<T> where T : class
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
    }
}
