namespace CleanArchitecture.WebApi.Models
{
    public class ApiResponse<T> : ApiResponseBase
    {
        public T Data { get; }

        private ApiResponse(T data, bool success, string message) : base(success, message) => Data = data;

        public ApiResponse(T data) : this(data, true, string.Empty)
        {

        }

        public ApiResponse(string message) : this(default, false, message)
        {

        }
    }
}