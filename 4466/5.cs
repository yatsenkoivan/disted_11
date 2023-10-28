using System;
using System.Text;

namespace Application
{

    class Program
    {

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int from = 5;
            int to = 90;

            for (int i = from; i <= to; i++)
            {
                if (i % 2 != 0 && i % 3 == 0 && i % 5 != 0)
                    Console.WriteLine(i);
            }

        }
    }
}

