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
            Console.Write("Введіть число: ");
            n = long.Parse(Console.ReadLine());
            long digits_amount = 0, digits_sum = 0;

            while (n > 0)
            {
                digits_sum += n % 10;
                n /= 10;
                digits_amount++;
            }

            Console.WriteLine($"Кількість цифр: {digits_amount} | Сума цифр: {digits_sum}");
        }
    }
}

