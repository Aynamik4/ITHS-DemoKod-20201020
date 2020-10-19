using System;
using System.Linq;

namespace NonGenericListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Non-Generic List Demo
            PersonList list = new PersonList();

            list.Add(new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 });
            list.Add(new Person { FirstName = "Nathalie", LastName = "Johansson", BirthYear = 2006 });
            list.Add(new Person { FirstName = "Kenneth", LastName = "Johansson", BirthYear = 2009 });

            Console.WriteLine(list[0].FirstName);

            foreach (Person item in list)
                Console.WriteLine(item.FirstName);

            Console.WriteLine(" ------______------______------");

            // Half-Generic List Demo
            HalfGenericList list2 = new HalfGenericList();

            list2.Add(new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 });
            list2.Add(new Person { FirstName = "Nathalie", LastName = "Johansson", BirthYear = 2006 });
            list2.Add(new Person { FirstName = "Kenneth", LastName = "Johansson", BirthYear = 2009 });

            Console.WriteLine(list2[0].FirstName);

            foreach (var item in list2)
                Console.WriteLine(item.FirstName);

            Console.WriteLine(" ------______------______------");

            // Generic List Demo
            GenericList<Person> list3 = new GenericList<Person>();

            list3.Add(new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 });
            list3.Add(new Person { FirstName = "Nathalie", LastName = "Johansson", BirthYear = 2006 });
            list3.Add(new Person { FirstName = "Kenneth", LastName = "Johansson", BirthYear = 2009 });

            Console.WriteLine(list3[0].FirstName);

            var resultSet = list3
                .Where(p => p.BirthYear > 2006)
                .Select(p => $"{p.FirstName} {p.LastName} {p.BirthYear}");

            foreach (var item in resultSet)
                Console.WriteLine(item);

            Console.WriteLine(" ------______------______------");

            var resultSet2 =
                Enumerable.Select(Enumerable.Where(list3, p => p.BirthYear > 2006), p => $"{p.FirstName} {p.LastName} {p.BirthYear}");

            foreach (var item in resultSet2)
                Console.WriteLine(item);

            Console.WriteLine(" ------______------______------");
        }
    }
}
