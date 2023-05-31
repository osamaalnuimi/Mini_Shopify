namespace Mini_Shopify.Entities.Models
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; } = string.Empty;
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
