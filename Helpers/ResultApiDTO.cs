namespace MicroSassApi.Helpers
{
    public class ResulApiDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? Error { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
