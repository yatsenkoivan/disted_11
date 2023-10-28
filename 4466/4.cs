using System;
using System.Text;

namespace Application
{

    class Program
    {

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            ulong n;
            Console.Write("Введіть число: ");
            n = ulong.Parse(Console.ReadLine());

            ulong reversed = 0;
            while (n > 0)
            {
                reversed *= 10;
                reversed += n % 10;
                n /= 10;
            }

            Console.WriteLine($"Розвернуте число: {reversed}");

        }
    }
}

