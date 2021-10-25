namespace CleanArchitecture.Application.Common
{
    public class RequestBase
    {
        public RequestBase(int pageNumber, int pageSize)
        {
            PageNumber = Validate(pageNumber, 1);
            PageSize = Validate(pageSize, 5);
        }

        public int PageNumber { get; }

        public int PageSize { get; }

        private static int Validate(int propertyValue, int defaultValue)
        {
            return propertyValue < 1 ? defaultValue : propertyValue;
        }
    }
}
