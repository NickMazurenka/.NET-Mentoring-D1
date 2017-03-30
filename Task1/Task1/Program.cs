using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			var p1 = new PersonClass {FirstName = "Alex", LastName = "Ivanov"};
			var p2 = new PersonClass {FirstName = "Alex", LastName = "Ivanov"};

			Console.WriteLine(p1.Equals(p2));
		}
	}
}
