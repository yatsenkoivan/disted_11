using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{

    class Program
    {

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int n, a, b;
            Console.WriteLine("Введіть кількість чисел в масиві: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть число \"a\": ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть число \"b\": ");
            b = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Random r = new Random();

            int multiplication_of_negativeNumbers = 1;

            for (int i=0; i<array.Length; i++)
            {
                array[i] = r.Next(a, b + 1);
                if (array[i] < 0) multiplication_of_negativeNumbers *= array[i];
            }

            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine($"1) {array.Count(x => (x % 2 == 0) && (x % 3 == 0 || x % 5 == 0))}");
            Console.WriteLine($"2) {multiplication_of_negativeNumbers}");
            Console.WriteLine($"3) {array.Max() + array.Min()}");
            Console.WriteLine($"4) {Array.IndexOf(array, array.Max())}");

        }
    }
}

