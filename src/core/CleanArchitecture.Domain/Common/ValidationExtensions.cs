using System;

namespace CleanArchitecture.Domain.Common
{
    static class ValidationExtensions
    {
        public static T Validate<T>(this T input)
        {
            var inputTypeCode = Type.GetTypeCode(typeof(T));

            switch (inputTypeCode)
            {
                case TypeCode.String:
                    if (string.IsNullOrWhiteSpace(input?.ToString()))
                    {
                        throw new InputViolationException(nameof(input));
                    }

                    break;
                case TypeCode.Double:
                    if (Convert.ToInt32(input.ToString()) < 1)
                    {
                        throw new InputViolationException(nameof(input));
                    }

                    break;
                case TypeCode.Object:
                    if (typeof(T) == typeof(Guid))
                    {
                        if (input == null || Guid.Parse(input.ToString() ?? string.Empty) == Guid.Empty)
                        {
                            throw new InputViolationException(nameof(input));
                        }
                    }

                    break;
            }

            return input;
        }
    }
}