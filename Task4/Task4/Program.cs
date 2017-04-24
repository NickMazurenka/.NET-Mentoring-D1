using System;
using StringToIntegerConverter;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "-2147483649";
            Console.WriteLine($"Example of converting: {StringToIntConverter.Convert(s)}");
        }
    }
}
