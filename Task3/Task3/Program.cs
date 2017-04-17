using System;
using System.ComponentModel;

namespace Task3
{
	class Program
	{
		private static string GetEnumDescription(Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
			var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(
				typeof(DescriptionAttribute),
				false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}

		static void Main()
		{
			var t = City.Minsk;
			var d = GetEnumDescription(t);
			Console.WriteLine("Enum value: " + t);
			Console.WriteLine("Enum description: " + d);

		}
	}
}
