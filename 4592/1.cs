using System;

namespace Application
{

    class Program
    {
        static public void Main()
        {
            int n, m, t;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            t = int.Parse(Console.ReadLine());
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

            for (int i = 0; i < m / 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] += t;
                }
            }

            int start = m / 2;
            if (m % 2 != 0) start++;

            double avg = 0;

            for (int i = start; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    avg += arr[i][j];
                }
            }

            avg /= (m - start) * n;

            Console.WriteLine(avg);

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
    }
}

