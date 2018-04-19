using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1-2+3-4+5...
namespace TestAddSub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddSub(101));
        }

        private static int AddSub(int v)
        {
            if (v <= 0)
            {
                return 0;
            }
            else
            {
                int a = 0;
                if (v % 2 == 0)
                {
                    a = -v / 2;
                }
                else
                {
                    a = v - (v - 1) / 2;
                }
                return a;
            }
        }
    }
}
