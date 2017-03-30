using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		private static void ClassExample()
		{
			var personsNumbers = new Dictionary<PersonClass, int>();
			var p1 = new PersonClass { FirstName = "Alex", LastName = "Ivanov" };
			var p2 = new PersonClass { FirstName = "Alex", LastName = "Ivanov" };
			var p3 = new PersonClass { FirstName = "Kim", LastName = "Kuan" };

			personsNumbers[p1] = 4;
			personsNumbers[p2] = 18;
			personsNumbers[p3] = 27;

			Console.WriteLine("P1 number is " + personsNumbers[p1]);
			Console.WriteLine("P2 number is " + personsNumbers[p2]);
			Console.WriteLine("P3 number is " + personsNumbers[p3]);
		}

		private static void StructExample()
		{
			var personsNumbers = new Dictionary<PersonStruct, int>();
			var p1 = new PersonStruct { FirstName = "Alex", LastName = "Ivanov" };
			var p2 = new PersonStruct { FirstName = "Alex", LastName = "Ivanov" };
			var p3 = new PersonStruct { FirstName = "Kim", LastName = "Kuan" };

			personsNumbers[p1] = 4;
			personsNumbers[p2] = 18;
			personsNumbers[p3] = 27;

			Console.WriteLine("P1 number is " + personsNumbers[p1]);
			Console.WriteLine("P2 number is " + personsNumbers[p2]);
			Console.WriteLine("P3 number is " + personsNumbers[p3]);
		}

		static void Main(string[] args)
		{
			ClassExample();
			StructExample();
		}
	}
}
