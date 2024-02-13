using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application
{

    class Program
    {
        static readonly string inputPath = "input.txt";
        static readonly string outputPath = "output.txt";

        static public void Main()
        {
            StreamReader sr = new StreamReader(inputPath);

            int S = int.Parse(sr.ReadLine());
            int N = int.Parse(sr.ReadLine());


            string line = sr.ReadLine();
            IEnumerable<byte> degrees = line.Split(' ').Select(x => byte.Parse(x));

            line = sr.ReadLine();
            double[] salaries = line.Split(' ').Select(x => double.Parse(x)).ToArray();

            sr.Close();

            StreamWriter sw = new StreamWriter(outputPath);

            switch(S)
            {
                case 1:
                    int k = degrees.Count(x => x==1);
                    sw.WriteLine(k);
                    break;
                case 2:
                    changeSalaries(ref salaries, degrees.ToArray());
                    sw.WriteLine(string.Join(" ", salaries));
                    break;
                case 3:
                    changeSalaries(ref salaries, degrees.ToArray());
                    double max = salaries.Max();
                    sw.WriteLine(max);
                    break;
            }

            sw.Close();

        }

        static void changeSalaries(ref double[] salaries, byte[] degrees)
        {
            for (int i=0; i<salaries.Length; i++)
            {
                if (degrees[i] == 1) salaries[i] *= 1.2;
                else salaries[i] *= 1.1;
            }
        }
    }
}

