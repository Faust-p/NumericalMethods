using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Solving.Func func = Solving.Function;
            Solving.DFunc dfunc = Solving.DFunction;
            TableInfo(func, dfunc);

            Console.ReadKey();
        }

        private static void TableInfo(Solving.Func f, Solving.DFunc df)
        {
            Console.WriteLine("Введите х мин");
            double X1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите х макс");
            double X2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            double step = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите эпсилон");
            double eps = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Выберите метод");
            double choice = Convert.ToDouble(Console.ReadLine());

            List<(double X1, double X2, double Root)> segments;
            segments = new List<(double X1, double X2, double Root)>();

            double root;
            int count = 0;
            Console.WriteLine("Уточняемый  |  Уточнённый  |  f(уточнённый)  |  Количество итераций");
            if (choice == 0)
            {
                foreach (var item in segments)
                {
                    root = Solving.HalfDivision(f, item.X1, item.X2, eps, out count);
                    Console.WriteLine("  {0}      |      {1}      |      {2}      |      {3}", item.Root, root, f(root), count);
                }
            }
            if (choice == 1)
            {
                foreach (var item in segments)
                {
                    root = Solving.Tangent(f, df, item.X1, item.X2, eps, out count);
                    Console.WriteLine("  {0}      |      {1}      |      {2}      |      {3}", item.Root, root, f(root), count);
                }
            }
            if (choice == 2)
            {
                foreach (var item in segments)
                {
                    root = Solving.Chord(f, item.X1, item.X2, eps, out count);
                    Console.WriteLine("  {0}      |      {1}      |      {2}      |      {3}", item.Root, root, f(root), count);
                }
            }
        }
    }
}
