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
            IEnumerable<byte> days = line.Split(' ').Select(x => byte.Parse(x));

            line = sr.ReadLine();
            double[] temperatures = line.Split(' ').Select(x => double.Parse(x)).ToArray();

            sr.Close();

            StreamWriter sw = new StreamWriter(outputPath);


            double avg;

            switch(S)
            {
                case 1:
                    int k = days.Count(x => x<15);
                    sw.WriteLine(k);
                    break;
                case 2:
                    avg = temperatures.Average();
                    sw.WriteLine(avg);
                    break;
                case 3:
                    avg = temperatures.Average();
                    IEnumerable<double> deltas = temperatures.Select(x => x - avg);
                    sw.WriteLine(string.Join(" ", deltas));
                    break;
            }

            sw.Close();

        }
    }
}

