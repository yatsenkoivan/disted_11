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

            int res = 0;
            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n/2; j++)
                {
                    if (arr[i][j] < 0 && arr[i][j] < k) res++;
                }
            }

            int start = n / 2;
            if (n % 2 != 0) start++;
            for (int i=0; i<m; i++)
            {
                for (int j=start; j<n; j++)
                {
                    if (i % 2 == 0 || j % 2 == 0) arr[i][j] *= arr[i][j];
                }
            }

            Console.WriteLine(res);
            for (int i=0; i<m; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
            
        }
    }
}

