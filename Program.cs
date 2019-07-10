using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String name;
            String pattern = ",";
            Console.WriteLine("Write a Line");
            name = Console.ReadLine();
            String[] elements = System.Text.RegularExpressions.Regex.Split(name, pattern);
            foreach (var element in elements)
                Console.WriteLine(element);
            Console.ReadLine();
        }
    }
}
