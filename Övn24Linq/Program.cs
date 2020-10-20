using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Linq.Enumerable;

namespace Övn24Linq
{
    internal static class Utils
    {
        public static bool Between(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            AddPersonsToList(persons);
            Console.WriteLine($"Totalt antal rader exklusive dubletter: {persons.Count}");
            //NamesThatStartsWith("And", persons);
            //NameDayAt(new DateTime(2020, 7, 23), persons);
            //NameStartsWithAndNameDayInMonth("P", persons);
            //MatchingNames(persons);
            //MatchingNameDay(persons);
            //NumberOfNamesForEachInitialLetter(persons);
            //NumberOfNamesForEachMonth(persons);
            //NumberOfNamesForEachQuarter(persons);
            FiveMostCommonNameDays(persons);
        }

        private static void FiveMostCommonNameDays(List<Person> persons)
        {
            var q = persons
                .GroupBy(p => p.NameDay)
                .OrderByDescending(g => g.Count())
                .Take(5);

            var resultSet = Enumerable.Take(Enumerable.OrderByDescending(Enumerable.GroupBy(persons, p => p.NameDay), g => g.Count()), 5);

            foreach (var group in q)
                Console.WriteLine($"{group.Key.ToShortDateString()} {group.Count()}");
        }

        static int Quarter(int month)
        {
            if (Utils.Between(month, 1, 3)) return 1;
            else
                if (Utils.Between(month, 4, 6)) return 2;
            else
                if (Utils.Between(month, 7, 9)) return 3;
            else
                if (Utils.Between(month, 10, 12)) return 4;
            else
                return 0;
        }

        private static void NumberOfNamesForEachQuarter(List<Person> persons)
        {
            var q = persons
                .OrderBy(p => p.NameDay.Month)
                .GroupBy(g => Quarter(g.NameDay.Month));

            foreach (IGrouping<int, Person> group in q)
                Console.WriteLine($"Kvartal {group.Key}: {group.Count()}");
        }


        private enum MonthName
        {
            januari = 1, februari, mars, april, maj, juni, juli, augusti, september, oktober, november, december
        }

        private static void NumberOfNamesForEachMonth(List<Person> persons)
        {
            var q = persons
                .GroupBy(p => p.NameDay.Month)
                .OrderByDescending(g => g.Count());

            foreach (var group in q)
                if (((MonthName)group.Key).ToString().Length >= 8)
                    Console.WriteLine($"{(MonthName)group.Key}\t{group.Count()}");
                else
                    Console.WriteLine($"{(MonthName)group.Key}\t\t{group.Count()}");
        }


        private static void NumberOfNamesForEachInitialLetter2(List<Person> persons)
        {
            // Query Syntax.

            var p7 =
                from person in persons
                orderby person.Name
                group person by person.Name[0];

            foreach (var people in p7)
            {
                Console.WriteLine($"Key: {people.Key} Total: {people.Count()}");
            }
        }

        private static void NumberOfNamesForEachInitialLetter(List<Person> persons)
        {
            var resultSet = persons
                .GroupBy(n => n.Name[0])
                .OrderByDescending(k => k.Count())
                .Take(3);

            foreach (IGrouping<char, Person> group in resultSet)
            {
                Console.WriteLine($"{group.Key} ({group.Count()})");

                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item.Name}, {item.NameDay.ToShortDateString()}");
                }
            }
        }

        private static void MatchingNameDay(List<Person> persons)
        {
            Console.Write("Mata in ett datum (MMDD): ");
            string input = Console.ReadLine();
            int month = int.Parse(input.Substring(0, 2));
            int day = int.Parse(input.Substring(2, 2));

            var resultSet = persons
                .Where(p => p.NameDay.Month == month && p.NameDay.Day == day)
                .Select(p => $"{p.Name} {p.NameDay}");

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }

        private static void MatchingNames(List<Person> persons)
        {
            Console.Write("Mata in ett namn eller en del av ett namn: ");
            string input = Console.ReadLine();

            var resultSet = persons
                .Where(p => p.Name.ToLower().Contains(input.ToLower()))
                .Select(p => p.Name);

            foreach (var name in resultSet)
            {
                Console.WriteLine(name);
            }
        }

        private static void NameStartsWithAndNameDayInMonth(string startsWith, List<Person> persons)
        {
            var resultSet = persons
                .Where(p => p.NameDay.Month == 4 && p.Name.ToLower().StartsWith(startsWith.ToLower()))
                .Select(p => $"{p.Name} {p.NameDay}");

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }

        private static void NameDayAt(DateTime dateTime, List<Person> persons)
        {
            var resultSet = persons
                .Where(p => p.NameDay.Month == dateTime.Month && p.NameDay.Day == dateTime.Day)
                .Select(p => $"{p.Name} {p.NameDay}");

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }

        private static void NamesThatStartsWith(string startsWith, List<Person> persons)
        {
            var resultSet = persons
                .Where(p => p.Name.StartsWith(startsWith))
                .Select(p => p.Name);

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }

        static void AddPersonsToList(List<Person> persons)
        {
            const string filePath = @"C:\Users\hakan\OneDrive\Dokument\GitHub\ITHS-DemoKod-20201020\Övn24Linq\names.csv";
            int rowCount = 0;
            foreach (string person in File.ReadLines(filePath, System.Text.Encoding.UTF7))
            {
                string[] personData = person.Split(';');

                if (PersonNotInList(personData[0], persons))
                {
                    Person p = new Person();
                    p.Name = personData[0];
                    p.NameDay = DateTime.Parse(personData[1]);
                    persons.Add(p);
                }

                rowCount++;
            }

            Console.WriteLine($"Totalt antal rader inklusive dubletter: {rowCount}");
        }

        private static bool PersonNotInList(string name, List<Person> persons)
        {
            bool nameFound = false;

            foreach (Person person in persons)
            {
                nameFound = person.Name.ToLower() == name.ToLower();

                if (nameFound)
                    break;
            }

            return !nameFound;
        }
    }
}
