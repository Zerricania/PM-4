using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWPFApp
{
    internal static class MathOperations
    {
        public static string Sum(double a, double b)
        {
            var res = a + b;
            return res.ToString();
        }

        public static string Percentage(double a, double b)
        {
            var res = a * (b / 100);
            return res.ToString();
        }

        public static string Divide(double a, double b)
        {
            if (b == 0)
            {
                return "0";
            }
            var res = a / b;
            return res.ToString();
        }

        public static string Subtract(double a, double b)
        {
            var Res = a - b;
            return Res.ToString();
        }

        public static string Factorial(double a)
        {
            int num = (int)a;
            long res = 1;

            for (int i = 2; i <= num; i++)
            {
                res *= i;
            }
            return res.ToString();
        }

        public static string Power(double a, double b)
        {
            var res = Math.Pow(a, b);
            return res.ToString();
        }

        public static string Multiply(double a, double b)
        {
            var res = a*b;
            return res.ToString();
        }


    }
}
