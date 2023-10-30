using System;
using System.Linq;

namespace Application
{

    class Program
    {
        static public void Main()
        {
            int n, m, k1, k2;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            k1 = int.Parse(Console.ReadLine());
            k2 = int.Parse(Console.ReadLine());
            int[][] arr = new int[m][];

            for (int i = 0; i < m; i++)
            {
                string[] values = Console.ReadLine().Split(' ');
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = int.Parse(values[j]);
                }
            }

            (arr[k1], arr[k2]) = (arr[k2], arr[k1]);
            Console.WriteLine(arr.Min(x => x.Min()));
            for (int i=0; i<m; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
            
        }
    }
}

