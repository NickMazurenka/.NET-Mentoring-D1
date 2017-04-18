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

		private static string GetCustomEnumDescription(Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
			var attributes = (CustomDescriptionAttribute[])fi.GetCustomAttributes(
				typeof(CustomDescriptionAttribute),
				false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}



		static void Main()
		{
			Console.WriteLine("Desctiption attribute:");
			var t = City.Minsk;
			var d = GetEnumDescription(t);
			Console.WriteLine("Enum value: " + t);
			Console.WriteLine("Enum description: " + d);

			Console.WriteLine("Custom attribute:");
			var ct = CustomCity.Minsk;
			var cd = GetCustomEnumDescription(ct);
			Console.WriteLine("Custom enum value: " + ct);
			Console.WriteLine("Custom enum description: " + cd);
		}
	}
}
