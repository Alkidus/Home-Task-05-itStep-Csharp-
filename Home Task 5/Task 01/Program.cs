/*Реализовать класс    для хранения    комплексного числа.
Выполнить    в нем    перегрузку всехнеобходимых операторов для успешной компиляции 
следующего фрагмента кода:
Complex z = newComplex(1, 1);
Complex z1; z1 = z - (z* z * z - 1) / (3 * z * z);  
Console.WriteLine("z1 =  {0}", z1);*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task_01
{
    class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public Complex() { }
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public override string ToString()
        {
            return $"{Re: 0.00} + {Im: 0.0}i";
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex { Re = c1.Re + c2.Re, Im = c1.Im + c2.Im };
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex { Re = c1.Re - c2.Re, Im = c1.Im - c2.Im };
        }
        public static Complex operator -(Complex c1, int c2)
        {
            return new Complex { Re = c1.Re - c2, Im = c1.Im };
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            //(a+bi)(c+di) = (ac-bd)+(bc + ad)i
            //a = c1.Re; b = c1.Im; c = c2.Re; d = c2.Im;
            return new Complex { Re = (c1.Re * c2.Re - c1.Im * c2.Im), Im = (c1.Im * c2.Re + c1.Re * c2.Im) };
        }
        public static Complex operator *(int c1, Complex c2)
        {
            return new Complex { Re = c1 * c2.Re, Im = c1 * c2.Im };
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            //Re = (ac+bd)/(cc+dd); Im = (bc-ad)/(cc+dd)
            double a = c1.Re; double b = c1.Im; double c = c2.Re; double d = c2.Im;
            return new Complex { Re = (a * c + b * d) / (c * c + d * d), Im = (b * c - a * d) / (c * c + d * d) };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Green;
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            WriteLine("z = {0}", z);
            WriteLine("z1 = {0}", z1);
            ReadKey();
        }
    }
}
