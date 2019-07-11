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
        public static void Instruction()
        {
            Console.WriteLine("## Instructions");
            Console.WriteLine("     a robot that can receive commands in order to move it.");
            Console.WriteLine("     These commands will tell the robot to go forwards or backwards, and turn left or right.");
            Console.WriteLine("     These commands will be  in the format <command><number>. ");
            Console.WriteLine("     For example 'L1' means 'turn left by 90 degrees once'.  'B2' would mean go backwards 2 units.");
            Console.WriteLine(" ");
            Console.WriteLine("     Inputs: - a string of comma-separated commands eg `F1,R1,B2,L1,B3`");
            Console.WriteLine("     Output: - the minimum amount of distance to get back to the starting point (`4` in this case)");
        }
        static void Main(string[] args)
        {
            // the initial Input i.e. commands
            String command;
            // Option here is the Y/N option from While loop to continue code execution. 
            String option;
            // Split the comma separated values.
            String pattern = ",";
            
            Instruction();
            do
            {
                Int32 distance = 0;
                // Keeps track of R's input
                Int32 RLocation = 0;
                // Kepps track of L's input
                Int32 LLocation = 0;
                Console.WriteLine("  ");
                Console.WriteLine("Please Input the Robot Commands in Comma separated Values");
                
                command = Console.ReadLine();
                
                String[] elements = System.Text.RegularExpressions.Regex.Split(command, pattern);
                foreach (var element in elements)
                {
                    String newPattern = @"([|A-Z|a-z| ]*)([\d]*)";
                    var match = Regex.Match(element, newPattern);
                    var value = match.Groups[1].Value;
                    var digit = int.Parse(match.Groups[2].Value);

                    if (value == "F")
                    {
                        if (digit > 0 && RLocation % 4 == 0 && LLocation == 0)
                        {
                            distance += digit;

                        }
                        else if (digit > 0 && RLocation == 0 && LLocation % 4 == 0)
                        {
                            distance += digit;

                        }
                        // new line
                        else if (digit > 0 && LLocation % 2 == 1 && RLocation == 0)
                        {
                            distance += digit;
                        }
                        // yet to calc for Rloc
                        else if (digit > 0 && LLocation == 0 && RLocation % 2 == 1)
                        {
                            distance += digit;
                        }

                        else if (digit > 0 && RLocation % 4 != 0 && LLocation == 0)
                        {
                            distance -= digit;
                        }
                        else if (digit > 0 && RLocation == 0 && LLocation % 4 != 0)
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


                    else if (value == "L")
                    {
                        if (digit > 0)
                        {
                            LLocation += digit;
                            Console.WriteLine(LLocation);
                        }
                        else
                        {
                            LLocation = 0;
                        }
                    }

                }
                // To print the magnitude alone of the integer and omit the sign using Math.Abs()
                Console.WriteLine("The minimum amount of distance to get back to the starting point  " + Math.Abs(distance));
                
                Console.WriteLine("Do you wish to execute command again? Enter Y/N");
                option = Console.ReadLine();
            } while (option == "Y" || option == "y");
        }
    }
}
