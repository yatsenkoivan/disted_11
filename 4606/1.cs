using System;
using System.IO;

namespace Application
{
    class Program
    {

        static public void Func2(ref int[] arr)
        {
            for (int i=0; i<arr.Length; i++)
            {
                if (i % 2 == 0) arr[i] = 222;
            }
        }

        static public void InsertionSort(ref int[] arr)
        {
            for (int i=1; i<arr.Length; i++)
            {
                for (int j=i; j>0; j--)
                {
                    if (arr[j] < arr[j-1])
                    {
                        (arr[j], arr[j-1]) = (arr[j-1], arr[j]);
                    }
                    else
                        break;
                }
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

            int count = 0;
            StreamWriter output = new StreamWriter("output.txt");
            switch (k)
            {
                case 1:
                    InsertionSort(ref arr);
                    break;
                case 2:
                    Func2(ref arr);
                    break;
                case 3:
                    for (int i = 0; i < n; i++)
                    {
                        if (arr[i] > 0 && arr[i]%5 == 0) count++;
                    }
                    output.WriteLine(count);
                    output.Close();
                    return;
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

