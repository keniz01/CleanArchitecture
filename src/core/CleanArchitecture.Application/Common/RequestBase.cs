namespace CleanArchitecture.Application.Common
{
    public abstract class RequestBase
    {
        private int _pageNumber, _pageSize;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = Validate(value, 1);
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = Validate(value, 10);
        }

        private static int Validate(int propertyValue, int defaultValue)
        {
            return propertyValue < 1 ? defaultValue : propertyValue;
        }
    }
}
