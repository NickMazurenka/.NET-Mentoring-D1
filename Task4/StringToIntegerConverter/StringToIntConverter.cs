using System;

namespace StringToIntegerConverter
{
    /// <summary>
    /// Class to convert
    /// </summary>
    public static class StringToIntConverter
    {
        /// <summary>
        /// Convert string to integer
        /// </summary>
        /// <param name="s">String to convert</param>
        /// <returns>Converted integer</returns>
        /// <exception cref="ArgumentException">If converted string is null</exception>
        /// <exception cref="FormatException">If converted string has incorrect format</exception>
        /// <exception cref="OverflowException">If resulting int is out of int value bounds</exception>
        /// <remarks>Works with positive and negative values</remarks>
        public static int Convert(string s)
        {
            // Check input data
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException($"Conevrted string {nameof(s)} cannot be null or whitespace");

            var result = 0;
            var index = 0;
            var positive = true;
            if (s[0] == '-')
            {
                positive = false;
                index++;
            }
            else if (s[0] == '+')
                index++;

            for (; index < s.Length; index++)
            {
                if (s[index] > '9' || s[index] < '0')
                    throw new FormatException($"Invalid character at position {index}");
                try
                {
                    result = checked(result * 10 + (s[index] - '0'));
                }
                catch (OverflowException e)
                {
                    throw new OverflowException($"Overflow on {index} position when converting {s} string", e);
                }
            }

            return result * (positive ? 1 : -1);
        }
    }
}
