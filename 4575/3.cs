using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{

    abstract class Prism
    {
        protected int h;
        public virtual double Volume()
        {
            double V = BaseArea() * h;
            return V;
        }
        public double FullArea()
        {
            double S_full = SideArea() + 2 * BaseArea();
            return S_full;
        }
        public double SideArea()
        {
            double S_side = Perimeter() * h;
            return S_side;
        }
        public abstract double Perimeter();
        public abstract double BaseArea();
    }


    class TriangularPrism : Prism
    {
        private int a, b, c;
        public TriangularPrism(int a, int b, int c, int h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }
        public override double Perimeter()
        {
            double P = a + b + c;
            return P;
        }
        public override double BaseArea()
        {
            double p = (a+b+c) / 2.0;
            double S_base = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S_base;
        }
    }

    class Parallelepiped : Prism
    {
        private int a, b;
        private double alpha_rad;
        public Parallelepiped(int a, int b, int alpha, int h)
        {
            this.a = a;
            this.b = b;
            this.alpha_rad = alpha * Math.PI / 180.0;
            this.h = h;
        }
        public override double Perimeter()
        {
            double P = 2 * (a + b);
            return P;
        }
        public override double BaseArea()
        {
            double S_base = a * b * Math.Sin(alpha_rad);
            return S_base;
        }
    }

    class Program
    {

        static public void Main()
        {
            int N;
            int a = 0, b = 0, c = 0, h = 0;
            int alpha=0;
            N = int.Parse(Console.ReadLine());
            switch (N)
            {
                case 1:
                    a = int.Parse(Console.ReadLine());
                    b = int.Parse(Console.ReadLine());
                    c = int.Parse(Console.ReadLine());
                    h = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    a = int.Parse(Console.ReadLine());
                    b = int.Parse(Console.ReadLine());
                    alpha = int.Parse(Console.ReadLine());
                    h = int.Parse(Console.ReadLine());
                    break;
                default:
                    return;

            }

            Prism p;
            switch (N)
            {
                case 1:
                    p = new TriangularPrism(a, b, c, h);
                    break;
                case 2:
                    p = new Parallelepiped(a, b, alpha, h);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"V = {p.Volume()}");
            Console.WriteLine($"S_side = {p.SideArea()}");
            Console.WriteLine($"S_full = {p.FullArea()}");
        }
    }
}

