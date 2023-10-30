using System;
using System.Linq;

namespace Application
{

    class Program
    {

        static public void Main()
        {
            int n, k;
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                string[] values = Console.ReadLine().Split(' ');
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = int.Parse(values[j]);
                }
            }

            int res = 0;
            for (int i = 0; i < n; i++)
            {
                res += arr[i].Count(x => x % k == 0);
                for (int j = 0; j < n; j++)
                {
                    if (j > i) arr[i][j] = -arr[i][j];
                    if (j < i) arr[i][j] *= arr[i][j];
                }
            }

            Console.WriteLine(res);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
    }
}

