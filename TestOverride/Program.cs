using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.PrintFields();
        }
    }

    class A
    {
        public A()
        {
            PrintFields();
        }
        public virtual void PrintFields() { }
    }
    class B : A
    {
        int x = 1;
        int y;
        public B()
        {
            y = -1;
        }
        public override void PrintFields() => Console.WriteLine($"x={x}, y={y}");
    }
}
