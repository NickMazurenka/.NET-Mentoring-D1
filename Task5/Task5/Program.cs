using System;
using System.Collections;
using System.Collections.Generic;

namespace Task5
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    static class Program
    {
        static void Main()
        {
            var type = Type.GetType("Task5.Person");
            var listType = typeof(List<>).MakeGenericType(type);
            var list = (IList)Activator.CreateInstance(listType);

            for (int i = 0; i < 5; i++)
                list.GetType().GetMethod("Add").Invoke(list, new object[]
                {
                    new Person
                    {
                        Name = "Kim",
                        Surname = "Kuan_" + i
                    }
                });

            foreach (var person in list)
            {
                var p = person as Person;
                Console.WriteLine($"{p.Name} {p.Surname}");
            }
        }
    }
}
