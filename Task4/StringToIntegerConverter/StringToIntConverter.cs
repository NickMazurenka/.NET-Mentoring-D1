using System;

namespace StringToIntegerConverter
{
    public class StringToIntConverter
    {
        public static int Convert(string s)
        {
            // Check input data
            if (s == null)
                throw new ArgumentNullException($"Conevrted string {nameof(s)} cannot be null");

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
                    result = result * 10 + (s[index] - '0');
                }
                catch (OverflowException e)
                {
                    throw new OverflowException($"Overflow when ", e);
                }
            }

            return result * (positive ? 1 : -1);
        }
    }
}
