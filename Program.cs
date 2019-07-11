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
            Int32 distance = 0;
            Int32 Location = 0;
            Console.WriteLine("Write a Line");
            name = Console.ReadLine();
            String[] elements = System.Text.RegularExpressions.Regex.Split(name, pattern);
            foreach (var element in elements)
            {
                String newPattern = @"([|A-Z|a-z| ]*)([\d]*)";
                var match = Regex.Match(element,newPattern);
                var value = match.Groups[1].Value;
                var digit = int.Parse(match.Groups[2].Value); 
                if(value == "F")
                {
                    if( digit > 0 && Location == 0)
                    {
                        distance += digit;
                        
                    }
                }     
                else if (value == "B")
                {
                    if( digit > 0 && Location == 0)
                    {
                        distance -= digit;
                    }
                    else if (digit >0 && Location == 2)
                    {
                        distance += digit;
                    }
                    else
                    {
                        Console.WriteLine("Entered Wrong input");
                    }
                }
                else if (value == "R")
                {
                    if(digit> 0)
                    {
                        if( digit/2 == 1 && distance !=0 && digit%4 !=0)
                        {
                            Location = 2;                         
                        }
                        else if (digit%4 ==0)
                        {
                            Location = 0;
                        }
                        else
                        {
                            Location = 0;
                        }
                    }
                }
                else if (value == "L")
                {
                    if(digit > 0)
                    {
                        if (digit / 2 == 1 && distance != 0 && digit % 4 != 0)
                        {
                            Location = 2;
                        }
                        else if (digit % 4 == 0)
                        {
                            Location = 0;
                        }
                        else
                        {
                            Location = 0;
                        }
                    }
                }
            }
    // To print the magnitude alone of the integer and omit the sign using Math.Abs()
            Console.WriteLine(Math.Abs(distance));
                
            Console.ReadLine();
        }
    }
}
