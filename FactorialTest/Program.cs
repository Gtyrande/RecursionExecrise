using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//阶乘
namespace FactorialTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }
        static int Factorial(int n)
        {
            return Factorial(1, n);
        }
        static int Factorial(int a,int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return a;
            }
            else
            {
                return Factorial(a * n, n - 1);
            }
        }
    }
}
