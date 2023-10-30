using System;
using System.Linq;

namespace Application
{

    class Program
    {
        static public void Main()
        {
            int n, m, s1, s2;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            s1 = int.Parse(Console.ReadLine());
            s2 = int.Parse(Console.ReadLine());
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

            for (int i=0; i<m; i++)
            {
                (arr[i][s1], arr[i][s2]) = (arr[i][s2], arr[i][s1]);
            }

            int mx = int.MinValue;
            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (arr[i][j]%2 == 0) mx = Math.Max(mx, arr[i][j]);
                }
            }

            Console.WriteLine(mx);
            for (int i=0; i<m; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
    }
}

