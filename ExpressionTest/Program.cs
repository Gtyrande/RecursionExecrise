using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("aaa", "bbb");
            Console.WriteLine(p);
            p.DisplayName();
        }
    }
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
        }
        private string fName;
        private string lName;
        public override string ToString() => $"{fName} {lName}".Trim();
        public void DisplayName() => Console.WriteLine(ToString());
    }
}
