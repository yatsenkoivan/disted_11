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
                if (arr[i] % 3 == 0)
                    arr[i] = -arr[i];
            }
        }

        static public void BubbleSort2(ref int[] arr)
        {
            bool sorted;
            bool to_left = true;
            for (int i = 0; i < arr.Length; i++)
            {
                sorted = true;
                if (to_left)
                {
                    for (int j = 0; j < arr.Length - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                            sorted = false;
                        }
                    }
                }
                else
                {
                    for (int j = arr.Length - 1; j > 0; j--)
                    {
                        if (arr[j] < arr[j - 1])
                        {
                            (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                            sorted = false;
                        }
                    }
                }

                if (sorted) return;

                to_left = !to_left;
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
                    BubbleSort2(ref arr);
                    break;
                case 2:
                    Func2(ref arr);
                    break;
                case 3:
                    for (int i = 0; i < n; i++)
                    {
                        if (arr[i] < 0 || arr[i] > 13) count++;
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

