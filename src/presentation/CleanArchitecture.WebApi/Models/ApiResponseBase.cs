namespace CleanArchitecture.WebApi.Models
{
    public class ApiResponseBase
    {
        public bool Success { get; }

        public string Message { get; }

        public ApiResponseBase(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}