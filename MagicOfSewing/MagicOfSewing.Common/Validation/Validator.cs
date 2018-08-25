namespace MagicOfSewing.Common.Validation
{
    using System;

    public static class Validator
    {
        public static void EnsureNotNull(object obj, string message = "")
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void EnsureStringNotNullOrEmpty(string str, string message = "")
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
