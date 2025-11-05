using System;
using System.Collections.Generic;
using System.IO;

namespace LAB1_5
{
    public static class Tasks
    {
        private static char[] Consonants = { 'б', 'в', 'г', 'д', 'ж', 'з' };



//УДАЛИТЬ ЭЛЕМЕНТЫ ИЗ СПИСКА
        public static void Task1(List<int> L, int value)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i] == value)
                {
                    L.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Результат:");
            for (int i = 0; i < L.Count; i++)
                Console.Write(L[i] + " ");
            Console.WriteLine();
        }



//ЗАДАЧА 2 СВЯЗАННЫЙ СПИСОК ,ПОМЕНЯТЬ ЭЛЕМЕНТЫ МЕСТАМИ 
        public static void Task2(LinkedList<int> L, int E)
        {
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
            }

            Console.Write("Результат после перестановки:");
            foreach (var val in L)
                Console.Write(val + " ");
            Console.WriteLine();
        }

        public static void Task3()
        {
            List<HashSet<string>> viewers = new List<HashSet<string>>();
            viewers.Add(new HashSet<string>(new string[] { "назад в будущее", "код да винчи", "гладиатор" }));
            viewers.Add(new HashSet<string>(new string[] { "код да винчи", "гладиатор" }));
            viewers.Add(new HashSet<string>(new string[] { "гладиатор", "форрест гамп" }));

            HashSet<string> watchAll = new HashSet<string>();
            foreach (var viewer in viewers)
                foreach (var movie in viewer)
                    watchAll.Add(movie);

            HashSet<string> viewAll = new HashSet<string>(viewers[0]);
            for (int i = 1; i < viewers.Count; i++)
                viewAll.IntersectWith(viewers[i]);

            HashSet<string> viewSome = new HashSet<string>(watchAll);
            foreach (var movie in viewAll)
                viewSome.Remove(movie);

            Console.WriteLine("ВСЕ ЗРИТЕЛИ ПОСМОТРЕЛИ:");
            foreach (var m in viewAll) Console.WriteLine(m);

            Console.WriteLine("НЕКОТОРЫЕ ЗРИТЕЛИ ПОСМОТРЕЛИ:");
            foreach (var m in viewSome) Console.WriteLine(m);
        }

        public static void Task4(string filePath)
        {
            string text = File.ReadAllText(filePath).ToLower();
            char[] split = { ' ', ',', '.', '!', '?', ':', '\n' };
            string[] words = text.Split(split, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, int> usedWords = new Dictionary<char, int>();

            foreach (var word in words)
                foreach (var c in Consonants)
                    if (word.IndexOf(c) != -1)
                        if (usedWords.ContainsKey(c)) usedWords[c]++;
                        else usedWords[c] = 1;

            Console.Write("ЗВОНКИЕ СОГЛАСНЫЕ, БОЛЕЕ ЧЕМ В ОДНОМ СЛОВЕ:");
            foreach (var kv in usedWords)
                if (kv.Value > 1)
                    Console.Write(kv.Key + " ");
            Console.WriteLine();
        }

        public static void Task5(string filePath)
        {
            Dictionary<string, List<string>> phoneDict = new Dictionary<string, List<string>>();
            foreach (var line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string surname = parts[0];
                string initial = parts[1];
                string phone = parts[2];
                string code = phone.Substring(0, 5);
                if (!phoneDict.ContainsKey(code)) phoneDict[code] = new List<string>();
                phoneDict[code].Add(surname + " " + initial);
            }

            int total = 0;
            foreach (var list in phoneDict.Values)
                total += list.Count;

            double avg = (double)total / phoneDict.Count;
            Console.WriteLine("СРЕДНЕЕ КОЛИЧЕСТВО СОТРУДНИКОВ В ПОДРАЗДЕЛЕНИИ:" + avg.ToString("F2"));
        }

        public static void createInputFile(string filePath)
        {
            string[] lines =
            {
                "ИВАНОВ П.С. 555-66-77",
                "ПЕТРОВ А.В. 555-66-78",
                "СИДОРОВ И.Н. 555-77-88",
                "КУЗНЕЦОВ В.В 555-77-89"
            };
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("ФАЙЛ СОЗДАН: " + filePath);
        }
    }
}
