using System;
using System.ComponentModel;
using System.Reflection;

namespace Task3
{
	class Program
	{
		private static string GetEnumDescription(Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);
            return attribute.Description;
        }

		private static string GetCustomEnumDescription(Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
		    var attribute = (CustomDescriptionAttribute) fi.GetCustomAttribute(typeof(CustomDescriptionAttribute), false);
		    return attribute.Description;
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
