using System;
using System.Collections;
using System.Linq;

namespace GenericsCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListOfPerson list = new ListOfPerson();
            //list.Add(new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 });
            //list.Add(new Person { FirstName = "Marilyn", LastName = "Johansson", BirthYear = 1976 });
            //list.Add(new Person { FirstName = "Nathalie", LastName = "Johansson", BirthYear = 2006 });
            //list.Add(new Person { FirstName = "Kenneth", LastName = "Johansson", BirthYear = 2009 });

            //foreach (Person person in list)
            //{
            //    Console.WriteLine(person.FirstName);
            //}

            //Console.WriteLine("---------------");

            //foreach (Person person in list)
            //{
            //    Console.WriteLine(person.FirstName);
            //}

            MyList<Person> list = new MyList<Person>();

            list.Add(new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 });
            list.Add(new Person { FirstName = "Marilyn", LastName = "Johansson", BirthYear = 1976 });
            list.Add(new Person { FirstName = "Nathalie", LastName = "Johansson", BirthYear = 2006 });
            list.Add(new Person { FirstName = "Kenneth", LastName = "Johansson", BirthYear = 2009 });

            var resultSet = list
                .Where(p => p.BirthYear > 1976);

            foreach (Person person in resultSet)
            {
                Console.WriteLine(person.FirstName);
            }
        }
    }
}
