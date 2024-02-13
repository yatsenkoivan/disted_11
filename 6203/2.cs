using System;
using System.IO;
using System.Linq;

namespace Application
{

    class Human
    {
        public static readonly byte pensionAgeMale = 60;
        public static readonly byte pensionAgeFemale = 55;

        public bool IsMale
        {
            get; private set;
        }

        public double Age
        {
            get; private set;
        }

        public Human(bool _isMale, double age)
        {
            IsMale = _isMale;
            Age = age;
        }

        public double YearsBeforePension()
        {
            if (IsMale)
            {
                return Math.Max(pensionAgeMale - Age, 0);
            }
            else
            {
                return Math.Max(pensionAgeFemale - Age, 0);
            }
        }

    }

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
            byte[] genders = line.Split(' ').Select(x => byte.Parse(x)).ToArray();

            line = sr.ReadLine();
            double[] ages = line.Split(' ').Select(x => double.Parse(x)).ToArray();

            sr.Close();

            Human[] humans = new Human[N];
            for (int i = 0; i < N; i++)
            {
                humans[i] = new Human(genders[i] == 11, ages[i]);
            }

            StreamWriter sw = new StreamWriter(outputPath);

            switch(S)
            {
                case 1:
                    int k = humans.Count(h => h.IsMale);
                    sw.WriteLine(k);
                    break;
                case 2:
                    sw.WriteLine(string.Join(" ", from h in humans select h.YearsBeforePension()));
                    break;
                case 3:
                    sw.WriteLine(ages.Min());
                    break;
            }

            sw.Close();

        }
    }
}

