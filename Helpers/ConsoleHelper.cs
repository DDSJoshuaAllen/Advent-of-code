using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_of_code.Helpers
{
    public class ConsoleHelper
    {
        public static void PrintAnswer<T>(int day, int part, T answer)
        {
            Console.WriteLine($"Day: {day} Part: {part} Answer: {answer?.ToString()}");
        }
    }
}