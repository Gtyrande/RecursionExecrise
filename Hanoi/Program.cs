using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi(6, "A", "B", "C");
        }

        static void Hanoi(int n, string x, string y, string z)
        {
            if (n == 0) { }
            else
            {
                Hanoi(n - 1, x, z, y);
                Console.WriteLine(x + " -> " + y);
                Hanoi(n - 1, z, y, x);
            }                
        }
    }
}
