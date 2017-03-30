using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			var personsNumbers = new Dictionary<PersonClass, int>();
			var p1 = new PersonClass {FirstName = "Alex", LastName = "Ivanov"};
			var p2 = new PersonClass {FirstName = "Alex", LastName = "Ivanov"};
			var p3 = new PersonClass {FirstName = "Kim", LastName = "Kuan"};

			personsNumbers[p1] = 4;
			personsNumbers[p2] = 18;
			personsNumbers[p3] = 27;

			Console.WriteLine("P1 number is " + personsNumbers[p1]);
			Console.WriteLine("P2 number is " + personsNumbers[p2]);
			Console.WriteLine("P3 number is " + personsNumbers[p3]);
		}
	}
}
