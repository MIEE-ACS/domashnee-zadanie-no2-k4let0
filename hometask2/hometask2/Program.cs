using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask2
{
    class Program
    {
        static double GetR(int num)
            // получение радиуса
        {
            double r;
            do
            {
                Console.Write($"введите R{num}: ");
                r = double.Parse(Console.ReadLine());
            } while (r < 0);
            return r;
        }

        //участки графика
        static double Segment1(double x)
            // y=1
        {
            return 1;
        }
        static double Segment2(double x)
            // y=-1/2(x+4)
        {
            return -0.5*(x+4);
        }
        static double Segment3(double x, double r2)
            // дуга окружности с центром в (-2,0) и радиусом r2
        {
            return Math.Sqrt(r2 * r2 - (x + 2) * (x + 2));
        }
        static double Segment4(double x, double r1)
        // дуга окружности с центром в (1,0) и радиусом r1
        {
            return -Math.Sqrt(r1 * r1 - (x - 1) * (x - 1));
        }
        static double Segment5(double x)
            // y=-(x-2);
        {
            return -(x - 2);
        }
       
        static void Point(double x, double r1,double r2)
        // вывод значения функции в точке
        {
            if (x < -7 || x > 3) Console.WriteLine("Функция не определена");
            else if (x >= -7 && x < -6) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment1(x)); // участок 1
            else if (x >= -6 && x < -4) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment2(x)); // участок 2
            else if (x == -4) // в точке x=-4 может быть 1 или 2 значения функции
            {
                if (r2 > 2) Console.WriteLine("y1({0:0.00}) = {1:0.00} y2({0:0.00}) = {2:0.00}", x, Segment2(x), Segment3(x, r2)); // 2 значения
                else Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment2(x)); // 1 значение
            }
            else if (x > -4 && x < 0) //окружность радиуса r2 (участок 3)
            {
                if (x >= -2 - r2 && x <= -2 + r2) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment3(x, r2)); // точка на дуге
                else Console.WriteLine("Функция не определена"); // точка вне дуги
            }
            else if (x == 0) // в точке x=0 может быть 0 1 или 2 значения функции
            {
                if (r2 >= 2 && r1 >= 1 && !(r2 == 2 && r1 == 1)) Console.WriteLine("y1({0:0.00}) = {1:0.00} y2({0:0.00}) = {2:0.00}", x, Segment3(x, r2), Segment4(x, r1)); // 2 значения
                else if (r2 >= 2 && r1 <= 1) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment3(x, r2)); // 1 значение
                else if (r2 < 2 && r1 >= 1) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment4(x, r1)); // 1 значение
                else Console.WriteLine("Функция не определена"); // нет значений
            }
            else if (x > 0 && x < 2) // окружность радиуса r1 (участок 4)
            {
                if (x >= 1 - r1 && x <= 1 + r1) Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment4(x, r1)); // точка на дуге
                else Console.WriteLine("Функция не определена"); // точка вне дуги
            }
            else if (x == 2) // в точке x=2 может быть 1 или 2 значения функции
            {
                if (r1 > 1) Console.WriteLine("y1({0:0.00}) = {1:0.00} y2({0:0.00}) = {2:0.00}", x, Segment4(x, r1), Segment5(x)); // 2 значения
                else Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment5(x)); // 1 значение
            }
            else Console.WriteLine("y({0:0.00}) = {1:0.00}", x, Segment5(x)); // 5 участок
        }
        static void Main(string[] args)
        {
            double r1 = GetR(1);
            double r2 = GetR(2);
            for (double x = -7; x <= 3; x += 0.2)
            {
                Point(x, r1, r2);
                x = Math.Round(x, 2); // иначе теряется значение x=3
            }
        }
    }
}
