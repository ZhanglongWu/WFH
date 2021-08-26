namespace Wicresoft.WFH.Core
{
    using System;

    public class Check
    {
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static bool IsNotNull<T>(T value) where T : class
        {
            return value != null;
        }

        public static bool IsNotNull<T>(T? value) where T : struct
        {
            return value.HasValue;
        }
    }
}
