using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{

    class Triangle
    {
        protected int a;
        protected int b;
        protected int c;
        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public virtual double Area()
        {
            double p = (a + b + c) / 2.0;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }
        public double Perimeter()
        {
            return a + b + c;
        }
        public virtual double Radius()
        {
            double R = a * b * c / (4 * Area());
            return R;
        }
    }

    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(int a, int b) : base(a, b, a)
        { }

        public override double Area()
        {
            double S = b / 2.0 * Math.Sqrt(a * a - b * b / 4.0);
            return S;
        }

    }

    class EquilateralTriangle : IsoscelesTriangle
    {
        public EquilateralTriangle(int a) : base(a, a)
        { }

        public override double Area()
        {
            double S = Math.Sqrt(3) / 4.0 * a * a;
            return S;
        }

        public override double Radius()
        {
            double R = a * Math.Sqrt(3) / 3.0;
            return R;
        }
    }


    class Program
    {

        static public void Main()
        {
            int N, a = 0, b = 0, c = 0;
            N = int.Parse(Console.ReadLine());
            switch (N)
            {
                case 1:
                    a = int.Parse(Console.ReadLine());
                    b = int.Parse(Console.ReadLine());
                    c = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    a = int.Parse(Console.ReadLine());
                    b = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    a = int.Parse(Console.ReadLine());
                    break;
                default:
                    return;

            }

            Triangle t;
            switch (N)
            {
                case 1:
                    t = new Triangle(a, b, c);
                    break;
                case 2:
                    t = new IsoscelesTriangle(a, b);
                    break;
                case 3:
                    t = new EquilateralTriangle(a);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"S = {t.Area()}");
            Console.WriteLine($"P = {t.Perimeter()}");
            Console.WriteLine($"R = {t.Radius()}");
        }
    }
}

