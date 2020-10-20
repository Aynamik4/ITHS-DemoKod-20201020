using System;

namespace ExtensionMethodCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            //if(ExtensionMethods.IsOdd(9))
            //    Console.WriteLine("Udda tal");

            //int i = 7;
            //if(i.IsOdd())
            //    Console.WriteLine("Udda tal");

            //int j = ExtensionMethods.ToInt("1962");
            //int k = "1962".ToInt();

            if (ExtensionMethods.IsOdd(ExtensionMethods.ToInt(Console.ReadLine())))
                    Console.WriteLine("Udda tal!");

            if(Console.ReadLine().ToInt().IsOdd())
                Console.WriteLine("Udda tal!");
        }
    }
}
