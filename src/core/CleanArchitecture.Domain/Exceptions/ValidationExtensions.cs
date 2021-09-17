using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates domain inputs.
        /// </summary>
        /// <typeparam name="T">The input type.</typeparam>
        /// <param name="input">The input value.</param>
        /// <returns>The input value.</returns>
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