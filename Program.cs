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
            // Keeps track of R's input
            Int32 RLocation = 0;
            // Kepps track of L's input
            Int32 LLocation = 0;
            Console.WriteLine("Please Input the Robot Commands in Comma separated Values");
            System.Threading.Thread.Sleep(1000);
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
                    if( digit > 0 && RLocation%4 == 0 && LLocation==0)
                    {
                        distance += digit;
                        
                    }
                    else if (digit > 0 && RLocation == 0 && LLocation%4 == 0)
                    {
                        distance += digit;

                    }
                    // new line
                    else if ( digit >0 && LLocation%2 == 1 && RLocation == 0)
                    {
                        distance += digit;
                    }
                    // yet to calc for Rloc
                    else if (digit > 0 && LLocation == 0 && RLocation%2 == 1)
                    {
                        distance += digit;
                    }

                    else if (digit > 0 && RLocation%4 !=0 && LLocation == 0)
                    {
                        distance -= digit;
                    }
                    else if (digit > 0 && RLocation == 0 && LLocation%4 != 0)
                    {
                        distance -= digit;
                    }
                    else if (digit > 0 && RLocation == LLocation)
                    {
                        distance += digit;
                    }
                    else
                    {
                        Console.WriteLine("Entered Wrong input");
                    }
                }     
                else if (value == "B")
                {
                    if (digit > 0 && RLocation % 4 == 0 && LLocation == 0)
                    {
                        distance -= digit;

                    }
                    else if (digit > 0 && RLocation == 0 && LLocation % 4 == 0)
                    {
                        distance -= digit;

                    }
                    // new line
                    else if (digit > 0 && LLocation % 2 == 1 && RLocation == 0)
                    {
                        distance -= digit;
                    }
                    // yet to calc for Rloc
                    else if (digit > 0 && LLocation == 0 && RLocation % 2 == 1)
                    {
                        distance -= digit;
                    }

                    else if (digit > 0 && RLocation % 4 != 0 && LLocation == 0)
                    {
                        distance += digit;
                    }
                    else if (digit > 0 && RLocation == 0 && LLocation % 4 != 0)
                    {
                        distance += digit;
                    }
                    else if (digit > 0 && RLocation == LLocation)
                    {
                        distance -= digit;
                    }
                    else
                    {
                        Console.WriteLine("Entered Wrong input");
                    }
                }
                else if (value == "R")
                {
                    if (digit > 0)
                    {
                        RLocation += digit;
                    }
                    else
                    {
                        RLocation = 0;
                    }
                }

                //else if (value == "R")
                //{
                //    if(digit> 0)
                //    {
                //        if( digit%2 == 0 && distance !=0 && digit%4 !=0)
                //        {
                //            RLocation += digit;                         
                //        }
                //        else if (digit%4 ==0)
                //        {
                //            RLocation += digit;
                //        }
                //        else if (digit % 2 == 1)
                //        {
                //            LLocation += digit;

                //        }
                //        else
                //        {
                //            RLocation = 0;
                //        }
                //    }
                //}
                else if (value == "L")
                {
                    if(digit > 0)
                    {
                        LLocation += digit;
                    }
                    else
                    {
                        LLocation = 0;
                    }
                }
                //else if (value == "L")
                //{
                //    if(digit > 0)
                //    {
                //        if (digit%2 == 0 && distance != 0 && digit % 4 != 0)
                //        {
                //            LLocation += digit;
                            
                //        }
                //        else if (digit % 4 == 0)
                //        {
                //            LLocation += digit;
                //        }
                //        else if ( digit%2 == 1)
                //        {
                //            LLocation += digit;
                            
                //        }
                //        else
                //        {
                //            LLocation = 0;
                //        }
                //    }
                //}
            }
    // To print the magnitude alone of the integer and omit the sign using Math.Abs()
            Console.WriteLine("The minimum amount of distance to get back to the starting point  " + Math.Abs(distance));
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(20));
            Console.ReadLine();
        }
    }
}
