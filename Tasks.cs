using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace labor4
{
    public static class Tasks
    {
        private static char[] Consonants = { 'б', 'в', 'г', 'д', 'ж', 'з' };



        //ЗАДАНИЕ 1УДАЛИТЬ ЭЛЕМЕНТЫ ИЗ СПИСКА

        public static void Task1()
        {
            Console.WriteLine("ВВЕДИ ЭЛЕМЕНТЫ СПИСКА ЧЕРЕЗ ПРОБЕЛ:");
            string input = Console.ReadLine();

            List<object> L = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s =>
                {
                    if (int.TryParse(s, out int n))
                        return (object)n;
                    else
                        return (object)s;
                })
                .ToList();

            Console.WriteLine("Введите элемент для удаления:");
            string valToRemove = Console.ReadLine();

            L.RemoveAll(item => item.ToString() == valToRemove);

            Console.Write("Результат: ");
            foreach (var item in L)
                Console.Write(item + " ");
            Console.WriteLine();
        }





        //ЗАДАЧА 2 ДВУСВЯЗНЫЙ СПИСОК ,ПОМЕНЯТЬ ЭЛЕМЕНТЫ МЕСТАМИ В УКАЗАННЫХ ГРАНИЦАХ
        public static void Task2()
        {
            Console.WriteLine("ВВЕДИ ЖЛЕМЕНТЫ СПИСКА ЧЕРЕЗ ПРОБЕЛ:");
            string input = Console.ReadLine();

            LinkedList<int> L = new LinkedList<int>(
                input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
            );

            Console.Write("ВВЕДИ ЭЛЕМЕНТ E: ");
            int E = int.Parse(Console.ReadLine());


            //ПРОХОДИМ ПО ВСЕМ ЭЛЕМЕНТАМ СПИСКА,УСТАНОВИВ ПЕРВОЕ И ПОСЛЕДНЕЕ ЗНАЧЕНИЕ E
            LinkedListNode<int> first = null;
            LinkedListNode<int> last = null;
            var node = L.First;
            while (node != null)
            {
                if (node.Value == E)
                {
                    if (first == null) first = node;
                    last = node;
                }
                node = node.Next;
            }

            //ПЕРЕСТАВЛЯЕМ БЛИЖАЙШИЕ ЭЛЕМЕНТЫ ПОСЛЕ E1 И ДО E2 В ДВУСВЯЗНОМ СПИСКЕ
            if (first != null && last != null && first != last)
            {
                var left = first.Next;
                var right = last.Previous;
                while (left != null && right != null && left != right && left.Previous != right)
                {
                    int temp = left.Value;
                    left.Value = right.Value;
                    right.Value = temp;
                    left = left.Next;
                    right = right.Previous;
                }

                Console.WriteLine("ПЕРЕСТАНОВКА ВЫПОЛНЕНА!");
            }
            else
            {
                Console.WriteLine("ПЕРЕСТАНОВКА НЕВОЗМОЖНА ,E В СПИСКЕ ВСТРЕЧАЕТСЯ МЕНЬШЕ 2 РАЗ!");
            }

            Console.Write("СПИСОК ПОСЛЕ ПЕРЕСТАНОВКИ: ");
            foreach (var val in L)
                Console.Write(val + " ");
            Console.WriteLine();
        }





        //ЗАДАЧА 3 МНОЖЕСТВА УНИКАЛЬНЫХ ЭЛЕМЕНТОВ
        public static void Task3()
        {
            Console.Write("ВВЕДИТЕ КОЛИЧЕСТВО ЗРИТЕЛЕЙ: ");
            int n = int.Parse(Console.ReadLine());

            List<HashSet<string>> viewers = new List<HashSet<string>>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"ФИЛЬМЫ ЗРИТЕЛЯ {i + 1} ЧЕРЕЗ ЗАПЯТУЮ: ");
                string line = Console.ReadLine();

                //СТРОКА В ХЕШСЕТ
                HashSet<string> movies = new HashSet<string>(
                    line.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(f => f.Trim())
                );

                viewers.Add(movies);
            }

            //СМОТРЕЛ ХОТЯ БЫ ОДИН ЗРИТЕЛЬ,ВНЕШНИЙ ЦИКЛ ПРОХОД ПО КАЖДОМУ ЗРИТЕЛЮ ИЗ МНОЖЕСТВА ЗРИТЕЛЕЙ,ВНУТРЕННИЙ ДОБАВЛЯЕТ КАЖДЫЙ ФИЛЬМ
            HashSet<string> watchAll = new HashSet<string>();
            foreach (var viewer in viewers)
                foreach (var movie in viewer)
                    watchAll.Add(movie);

            //СМОТРЕЛИ ВСЕ ЗРИТЕЛИ,НАЧИНАЯ С ПЕРВОГО ЗРИТЕЛЯ ПОКА НЕ ПРОЦД1М ПО ВСЕМ,ВЫВОДИМ ТОЛЬКО ТЕ КОТОРЫЕ ПЕРЕСЕКАЮТСЯ ВО ВСЁМ МНОЖЕСТВЕ ИНТЕРСЕКТ
            HashSet<string> viewAll = new HashSet<string>(viewers[0]);
            for (int i = 1; i < viewers.Count; i++)
                viewAll.IntersectWith(viewers[i]);

            //СМОТРЕЛИ НЕКОТОРЫЕ ЗРИТЕЛИ,НА ОСНОВЕ ПОСМОТРЕЛИ ВСЕ ,УДАЛЯЕМ ТЕ ФИЛЬМЫ,КОТОРЫЕ ПОСМОТРЕЛ КАЖДЫЙ ЗРИТЕЛЬ.
            HashSet<string> viewSome = new HashSet<string>(watchAll);
            foreach (var movie in viewAll)
                viewSome.Remove(movie);

            Console.WriteLine("\nВСЕ ЗРИТЕЛИ ПОСМОТРЕЛИ:");
            foreach (var m in viewAll) Console.WriteLine(m);

            Console.WriteLine("\nНЕКОТОРЫЕ ЗРИТЕЛИ ПОСМОТРЕЛИ:");
            foreach (var m in viewSome) Console.WriteLine(m);
        }



        //ЗАДАЧА 4
        public static void Task4(string filePath)
        {
            string text = File.ReadAllText(filePath).ToLower();
            char[] split = { ' ', ',', '.', '!', '?', ':', '\n' };
            string[] words = text.Split(split, StringSplitOptions.RemoveEmptyEntries);


            //БУКВЫ ВСТРЕЧАЛИСЬ ОДИН РАЗ И БУКВЫ КОТОРЫЕ ПОВТОРЯЮТСЯ НЕСКОЛЬЛКО РАЗ
            HashSet<char> appeared = new HashSet<char>();
            HashSet<char> multiple = new HashSet<char>();


            //ЦИКЛ ПО КАЖДОМУ СЛОВУ ИЗ МАССИВА ВОРДС, НОВОЕ МНОЖЕСТВО ,ЕСЛИ В СЛОВЕ СОГЛАСНАЯ ,ТО ДОБАВЛЯЕМ В МНОЖЕСТВО
            foreach (var word in words)
            {



                //ЕСЛИ СОГЛАСНАЯ ЕСТЬ В СЛОВЕ ТО ДОБАВЛЯЕМ ВО МНОЖЕСТВО ВОРДЛЕТТЕРС
                HashSet<char> wordLetters = new HashSet<char>();
                foreach (var c in Consonants)
                {
                    if (word.Contains(c))
                        wordLetters.Add(c);
                }


                //ПРОХОД ПО МНОЖЕСТВУ СЧИТАЕМ УНИКАЛЬНЫЕ СОГЛАСНЫЕ 
                foreach (var c in wordLetters)
                {
                    if (!appeared.Add(c)) 
                        multiple.Add(c);   
                }
            }

            var result = multiple.ToList();
            result.Sort();

            Console.Write("ЗВОНКИЕ СОГЛАСНЫЕ, БОЛЕЕ ЧЕМ В ОДНОМ СЛОВЕ: ");
            foreach (var c in result)
                Console.Write(c + " ");
            Console.WriteLine();
        }




    }   
}
