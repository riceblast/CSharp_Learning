using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStackOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x = uint.MaxValue;
            Console.WriteLine(x);
            string binStr = Convert.ToString(x, 2);
            Console.WriteLine(binStr);
            try
            {
                uint y = checked(x + 1);
                Console.WriteLine(y);
            }
            catch(OverflowException ex)
            {
                Console.WriteLine("溢出");

            }
        }
    }


    class Person
    {
        public string name;

        public static List<Person> operator + (Person p1,Person p2)
        {
            List<Person> people = new List<Person>();
            people.Add(p1);
            people.Add(p2);
            for(int i = 0; i < 11; i++)
            {
                Person child = new Person();
                child.name = p1.name + p2.name + "s child";
                people.Add(child);
            }
            return people;
        }
    }
}
