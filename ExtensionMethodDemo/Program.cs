using System;
using System.Linq;

namespace ExtensionMethodDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Enumerable

            bool OK1 = ExtensionMethods.IsOdd(9);
            
            bool OK2 = 9.IsOdd();

            int i = 9;
            bool OK3 = i.IsOdd();

            int j = ExtensionMethods.ToInt("19");

            bool OK4 = ExtensionMethods.IsOdd(ExtensionMethods.ToInt("19"));

            bool OK5 = "19".ToInt().IsOdd();

            Person p = new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 };
            Console.WriteLine(p.CompleteName());
            Console.WriteLine(p.CompleteName2());
        }

        static string CompleteName2(this Person p)
        {
            return $"{p.FirstName} {p.LastName}";
        }
    }
}
