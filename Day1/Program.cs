using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day One Solution!");
            int partOneAnswer = partOne();
            Console.WriteLine($"Part one anwer is: {partOneAnswer}");
            int partTwoAnswer = partTwo();
            Console.WriteLine($"Part two answer is: {partTwoAnswer}");
        }

        public static int partOne()
        {
            var input = File.ReadAllLines(@"Input.txt").Select(y => int.Parse(y)).ToList();

            var currentValue = input.First();
            var total = 0;

            foreach(var measure in input)
            {
                if(measure > currentValue)
                {
                    total++;
                }
                currentValue = measure;
            }

            return total;
        }

        public static int partTwo()
        {
            var input = File.ReadAllLines(@"Input.txt").Select(y => int.Parse(y)).ToList();

            var sumCount = 0;
            var previousSum = input[0] + input[1] + input[2];

            for (var index = 0; index < input.Count - 2; index++)
            {
                var total = input[index] + input[index + 1] + input[index + 2];
                if (total > previousSum)
                {
                    sumCount++;
                }
                previousSum = total;
            }
            return sumCount;
        }
    }
}
