using lab67;
using System;

namespace Lab6_7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ТЕСТ КЛАССА LineSegment ===");

            Console.Write("Введите X: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите Y: ");
            double y = double.Parse(Console.ReadLine());

            LineSegment seg = new LineSegment(x, y);

            Console.WriteLine("Создан отрезок: " + seg);

            Console.Write("Введите число для проверки Contains: ");
            double v = double.Parse(Console.ReadLine());

            Console.WriteLine("Попадает ли число? " + seg.Contains(v));

            Console.WriteLine("Длина отрезка (!seg): " + !seg);

            Console.WriteLine("++: " + (++seg));

            Console.WriteLine("целое числоX: " + (int)seg);

            double yValue = seg; 
            Console.WriteLine("double Y: " + yValue);

            Console.Write("Введите d для операции +: ");
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine("seg + d = " + (seg + d));
            Console.WriteLine("d + seg = " + (d + seg));

            Console.Write("Введите число для проверки оператора <: ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine("попадает в отрезок < k ? " + (seg < k));
        }
    }
}
