using System;
using System.Collections.Generic;

namespace labor4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("== ЗАДАНИЕ 1 ==");
            Tasks.Task1();

            Console.WriteLine("\n== ЗАДАНИЕ 2 ==");
            Tasks.Task2();

            Console.WriteLine("\n== ЗАДАНИЕ 3 ==");
            Tasks.Task3();

            Console.WriteLine("\n== ЗАДАНИЕ 4 ==");
            Tasks.Task4("text.txt");

            
        }
    }
}
