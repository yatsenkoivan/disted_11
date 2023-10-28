using System;
using System.Text;

namespace Application
{

    class Program
    {


        static public void Main()
        {

            Console.OutputEncoding = Encoding.Unicode;

            long n;
            Console.Write("Введіть кількість елементів масиву:\n> ");
            n = long.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Random r = new Random();

            long sum = 0;
            int evenNumbers_amount = 0;

            for (long i = 0; i < n; i++)
            {
                arr[i] = r.Next(2, 16);
                sum += arr[i];
                if (arr[i] % 2 == 0)
                {
                    evenNumbers_amount++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Join(" ", arr));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Сумма: {sum} | Кількість парних чисел: {evenNumbers_amount}");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}

