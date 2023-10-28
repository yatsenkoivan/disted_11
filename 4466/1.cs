using System;
using System.Text;

namespace Application
{

    class Program
    {

        static public double CalcArea(ulong a, ulong b, ulong c)
        {
            double p = (a + b + c) / 2.0;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            ulong a, b, c;
            Console.WriteLine("Введіть довжини сторін трикутника: ");
            Console.Write("a = ");
            a = ulong.Parse(Console.ReadLine());
            Console.Write("b = ");
            b = ulong.Parse(Console.ReadLine());
            Console.Write("c = ");
            c = ulong.Parse(Console.ReadLine());

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Console.WriteLine("ERROR");
                return;
            }

            Console.WriteLine($"Площа: {CalcArea(a, b, c)}");

        }
    }
}

