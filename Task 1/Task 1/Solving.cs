using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class Solving
    {
        public delegate double Func(double x);
        public delegate double DFunc(double x);

        public static double Function(double x) => Math.Sin(x) + Math.Log(Math.Sin(x));
        public static double DFunction(double x) => Math.Cos(x) + 1 / Math.Tan(x);

        public static double HalfDivision(Func F, double x1, double x2, double eps, out int n)
        {
            n = 0;
            double c = double.NaN;
            while (F(x1) * F(x2) <= 0 && Math.Abs(x1 - x2) > eps)
            {
                n++;
                if (F(x1) == 0) return x1;
                if (F(x2) == 0) return x2;
                c = (x1 + x2) / 2;
                if (F(c) == 0) return c;
                else
                if (F(x1) * F(c) < 0) x2 = c;
                else x1 = c;
            }
            return c;
        }
        public static double Tangent(Func F, DFunc DF, double x1, double x2, double eps, out int n)
        {
            n = 0;
            while (Math.Abs(F(x1)) > eps && x1 < x2)
            {
                x1 -= F(x1) / DF(x1);
                n++;
            }
            return x1;
        }
        public static double Chord(Func F, double x1, double x2, double eps, out int n)
        {
            n = 0;
            while (Math.Abs(F(x1)) > eps)
            {
                x1 -= F(x1) * (x2 - x1) / (F(x2) - F(x1));
                n++;
            }
            return x1;
        }
    }
}
