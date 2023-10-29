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
                if (arr[i] % 2 == 0 || arr[i] % 7 == 0)
                    arr[i] += 10;
            }
        }

        static public void SelectionSort(ref int[] arr)
        {
            int mnIndex;
            for (int i=0; i<arr.Length; i++)
            {
                mnIndex = i;
                for (int j=i+1; j<arr.Length; j++)
                {
                    if (arr[j] < arr[mnIndex]) mnIndex = j;
                }
                (arr[i], arr[mnIndex]) = (arr[mnIndex], arr[i]);
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
                    SelectionSort(ref arr);
                    break;
                case 2:
                    for (int i = 0; i < n; i++)
                    {
                        if (arr[i] < 0) count++;
                    }
                    output.WriteLine(count);
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

