using System;
using System.IO;

namespace Application
{
    class Program
    {

        static public void Func3(ref int[] arr)
        {
            for (int i=0; i<arr.Length; i++)
            {
                if (arr[i] > 2 && arr[i] < 17)
                {
                    arr[i] *= arr[i];
                }
            }
        }

        static public void BubbleSort(ref int[] arr)
        {
            bool sorted;
            for (int i = 0; i<arr.Length; i++)
            {
                sorted = true;
                for (int j=0; j<arr.Length-i-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        sorted = false;
                    }
                }
                if (sorted) break;
            }
        }

        static public void Main()
        {
            
            StreamReader input = new StreamReader("input.txt");
            int n = int.Parse(input.ReadLine());
            string[] values = input.ReadLine().Split(' ');
            int[] arr = new int[n];
            for (int i=0; i<n; i++)
            {
                arr[i] = int.Parse(values[i]);
            }
            int k = int.Parse(input.ReadLine());
            input.Close();

            int odd_count = 0;
            StreamWriter output = new StreamWriter("output.txt");
            switch (k)
            {
                case 1:
                    BubbleSort(ref arr);
                    break;
                case 2:
                    for (int i=0; i<n; i++)
                    {
                        if (arr[i] % 2 != 0) odd_count++;
                    }
                    output.WriteLine(odd_count);
                    output.Close();
                    return;
                case 3:
                    Func3(ref arr);
                    break;
            }

            for (int i=0; i<n; i++)
            {
                output.Write(arr[i] + " ");
            }
            output.WriteLine();
            output.Close();
        }
    }
}

