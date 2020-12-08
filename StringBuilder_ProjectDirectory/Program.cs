using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"{new string('+', 50)}");
            WriteLine("String Builder Console Application");
            WriteLine($"{new string('+', 50)}");

            try
            {
                WriteLine("Provide the input string : ");
                string inputString = ReadLine();
                WriteLine("Provide cost of adding a character to output string (in $) : ");
                int addCost = int.Parse(ReadLine());
                WriteLine("Provide cost of adding a character to output string (in $) : ");
                int copyAppendCost = int.Parse(ReadLine());

                StringBuilder stringBuilder = new StringBuilder(inputString.Length, addCost, copyAppendCost);
                var cost = stringBuilder.ComputeMinimumCost(inputString);
                WriteLine("Minimum string building cost $ " + cost);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                WriteLine(new string('*', 50));
                WriteLine(ex.Message);
                WriteLine(new string('*', 50));
            }
            finally
            {
                Console.BackgroundColor = ConsoleColor.Black;
                WriteLine("Press any key to terminate..");
                Read();
            }
        }
    }
}
