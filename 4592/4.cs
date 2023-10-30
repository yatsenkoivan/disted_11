using System;
using System.Linq;

namespace Application
{

    class Program
    {
        static public void Main()
        {
            int n, m, k;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
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

            Console.WriteLine(arr[k].Sum());

            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (i % 2 == 0 && j % 3 == 0) arr[i][j] = 2012;
                }
            }

            for (int i=0; i<m; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }

        }
    }
}

