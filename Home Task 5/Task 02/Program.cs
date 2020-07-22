/*Разработать класс Fraction, представляющий простую дробь.
в классе  предусмотреть два  поля:  числитель и знаменатель дроби.
Выполнить перегрузку следу-ющих операторов: +,-,*,/,==,!=,<,>, true и false .
Арифметические действия и сравнение выполняется в соответствии с правилами работы с дробями.
Оператор true возвращает true если дробь правильная(числитель меньше знаменателя),
оператор false возвращает true если дробь неправильная(числитель больше знаменателя) .
Выполнить перегрузку операторов, необходимых для успешной компиляции следующего фрагмента кода:
Fraction f = newFraction(3, 4); 
int a = 10; 
Fraction f1 = f * a; 
Fraction f2 = a * f; 
double d = 1.5; 
Fraction f3 = f + d;*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task_02
{
    class Fraction
    {
        public int ches { get; set; }
        public int znam { get; set; }
        public Fraction() { }
        public Fraction(int ches, int znam)
        {
            this.ches = ches;
            this.znam = znam;
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction { ches = f1.ches * f2.znam + f2.ches * f1.znam, znam = f1.znam * f2.znam };
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction { ches = f1.ches * f2.znam - f2.ches * f1.znam, znam = f1.znam * f2.znam };
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction { ches = f1.ches * f2.ches, znam = f1.znam * f2.znam };
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction { ches = f1.ches * f2.znam, znam = f1.znam * f2.ches };
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Equals(f2);
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            if (f1.ches * f2.znam > f1.znam * f2.ches)
                return true;
            else
                return false;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            if (f1.ches * f2.znam < f1.znam * f2.ches)
                return true;
            else
                return false;
        }
        public static bool operator true(Fraction f1)
        {
            if (f1.ches < f1.znam)
                return true;
            else
                return false;
        }
        public static bool operator false(Fraction f1)
        {
            if (f1.ches > f1.znam)
                return true;
            else
                return false;
        }

        //
        //
        //
        //
        public static Fraction operator *(Fraction f1, int f2)
        {
            return new Fraction { ches = f1.ches * f2, znam = f1.znam };
        }
        public static Fraction operator *(int f2, Fraction f1)
        {
            return new Fraction { ches = f1.ches * f2, znam = f1.znam };
        }
        public static Fraction operator +(Fraction f1, double f2)
        {
            return new Fraction { ches = f1.ches * 10 + (int)(f1.znam * f2 * 10), znam = f1.znam * 10 };
        }
        public override string ToString()
        {
            return $"{ches}/{znam}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;
            WriteLine($"f1 = {f1}");
            WriteLine($"f2 = {f2}");
            WriteLine($"f3 = {f3}");
            WriteLine($"f1 == f2: {f1 == f2}");
            WriteLine($"f1 != f2: {f1 != f2}");
            WriteLine($"f1 > f3: {f1 > f3}");
            WriteLine($"f1 < f3: {f1 < f3}");
            if (f1)
                WriteLine($"{f1} - Дробь правильная");
            else
                WriteLine($"{f1} - Дробь неправильная");
            ReadKey();
        }
    }
}
