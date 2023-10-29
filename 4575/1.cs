using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{

    class Parallelogram
    {
        protected int d1;
        protected int d2;
        protected double alpha_rad;
        public Parallelogram(int d1, int d2, int alpha)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.alpha_rad = alpha * Math.PI / 180.0;
        }

        public virtual double Area()
        {
            double S = d1 * d2 * Math.Sin(alpha_rad) / 2.0;
            return S;
        }
        public virtual double Side()
        {
            double a = Math.Sqrt(Math.Pow(d1, 2)/4.0 + Math.Pow(d2, 2)/4.0 - d1*d2/2.0 * Math.Cos(alpha_rad));
            return a;
        }
        public virtual double Height()
        {
            double h = Area() / Side();
            return h;
        }
    }

    class Diamond : Parallelogram
    {
        public Diamond(int d1, int d2) : base(d1, d2, 90)
        {}
        public override double Area()
        {
            double S = d1 * d2 / 2.0;
            return S;
        }
        public override double Side()
        {
            double a = Math.Sqrt(Math.Pow(d1, 2) + Math.Pow(d2, 2)) / 2.0;
            return a;
        }
    }

    class Square : Diamond
    {
        public Square(int d1) : base(d1, d1)
        { }

        public override double Height()
        {
            return Side();
        }
    }


    class Program
    {

        static public void Main()
        {
            int N, d1=0, d2=0, alpha=0;
            N = int.Parse(Console.ReadLine());
            switch(N)
            {
                case 1:
                    d1 = int.Parse(Console.ReadLine());
                    d2 = int.Parse(Console.ReadLine());
                    alpha = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    d1 = int.Parse(Console.ReadLine());
                    d2 = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    d1 = int.Parse(Console.ReadLine());
                    break;
                default:
                    return;

            }

            Parallelogram p;
            switch (N)
            {
                case 1:
                    p = new Parallelogram(d1, d2, alpha);
                    break;
                case 2:
                    p = new Diamond(d1,d2);
                    break;
                case 3:
                    p = new Square(d1);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"S = {p.Area()}");
            Console.WriteLine($"a = {p.Side()}");
            Console.WriteLine($"h = {p.Height()}");
        }
    }
}

