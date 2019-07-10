using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            {
                String newPattern = @"([|A-Z|a-z| ]*)([\d]*)";
                var match = Regex.Match(element,newPattern);
                var value = match.Groups[1].Value;
                var digit = int.Parse(match.Groups[2].Value); 
                Console.WriteLine(value);
                Console.WriteLine(digit);
            }
                
            Console.ReadLine();
        }
    }
}
