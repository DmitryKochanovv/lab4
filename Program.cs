using System;
using System.Collections.Generic;

namespace LAB1_5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("== ЗАДАНИЕ 1 ==");
            Tasks.Task1(new List<int> { 1, 2, 3, 2, 5, 4, 2, 7, 9 }, 2);

            Console.WriteLine("\n== ЗАДАНИЕ 2 ==");
            LinkedList<int> ll = new LinkedList<int>(new int[] { 1, 2, 3, 4, 2, 5, 2, 6 });
            Tasks.Task2(ll, 2);

            Console.WriteLine("\n== ЗАДАНИЕ 3 ==");
            Tasks.Task3();

            Console.WriteLine("\n== ЗАДАНИЕ 4 ==");
            Tasks.Task4("text");

            Console.WriteLine("\n== ЗАДАНИЕ 5 ==");
            Tasks.createInputFile("phones.txt");
            Tasks.Task5("phones.txt");
        }
    }
}
