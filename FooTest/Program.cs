using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//斐波那契数
namespace FooTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Foo(30));
        }
        static int Foo(int n)
        {
            return Foo(1, 1, n - 1);
        }
        static int Foo(int a, int b, int n)
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
                return Foo(b, a + b, n - 1);
            }
        }
    }
}
