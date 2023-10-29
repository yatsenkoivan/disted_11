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
        public virtual double Radius1()
        {
            double R = a*b*c / (4 * Area());
            return R;
        }
        public virtual double Radius2()
        {
            double r = 2 * Area() / (a + b + c);
            return r;
        }
    }

    class RightTriangle : Triangle
    {
        public RightTriangle(int a, int b, int c) : base(a, b, c)
        { }

        public override double Area()
        {
            double S = a * b / 2.0;
            return S;
        }
        public override double Radius1()
        {
            double R = c / 2.0;
            return R;
        }

    }

    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(int a) : base(a, a, a)
        { }

        public override double Radius1()
        {
            double R = a * Math.Sqrt(3) / 3.0;
            return R;
        }
        public override double Radius2()
        {
            double r = a * Math.Sqrt(3) / 6.0;
            return r;
        }
    }


    class Program
    {

        static public void Main()
        {
            int N, a=0, b=0, c=0;
            N = int.Parse(Console.ReadLine());
            switch(N)
            {
                case 1:
                case 2:
                    a = int.Parse(Console.ReadLine());
                    b = int.Parse(Console.ReadLine());
                    c = int.Parse(Console.ReadLine());
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
                    t = new RightTriangle(a, b, c);
                    break;
                case 3:
                    t = new EquilateralTriangle(a);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"S = {t.Area()}");
            Console.WriteLine($"R = {t.Radius1()}");
            Console.WriteLine($"r = {t.Radius2()}");
        }
    }
}

