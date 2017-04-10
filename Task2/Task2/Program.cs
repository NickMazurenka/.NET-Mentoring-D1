using System;
using System.Collections.Generic;

namespace Task2
{
	class Program
	{
		static void Main()
		{
			var test = new Iterator<string>();
			test.Add("test1");
			test.Add("test2");

			Console.WriteLine("Default order");
			foreach (var item in test)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Reverse order");
			using (var rev = test.GetReverseEnumerator())
			{
				rev.MoveNext();
				Console.WriteLine(rev.Current);
				rev.MoveNext();
				Console.WriteLine(rev.Current);
			}
		}
	}
}
