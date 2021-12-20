using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day Two!");
            var pt1Ans = PartOne();
            Console.WriteLine($"Part one answer is: {pt1Ans}");
            var pt2Ans = PartTwo();
            Console.WriteLine($"Part one answer is: {pt2Ans}");
        }

        public static int PartOne()
        {
            var input = File.ReadAllLines(@"Input.txt").Select(line => new Step(line.Split(' ')[0],
                int.Parse(line.Split(' ')[1]))).ToList();

            int horizontal = 0;
            int depth = 0;
            foreach (var line in input)
            {
                switch (line.Action)
                {
                    case "forward":
                        horizontal += line.Amount;
                        break;
                    case "up":
                        depth -= line.Amount;
                        break;
                    case "down":
                        depth += line.Amount;
                        break;
                }
            }
            int answer = horizontal * depth;
            Console.WriteLine($"Horizontal {horizontal} * Depth {depth} equals {answer}");
            return answer;
        }

        public static int PartTwo()
        {
            var input = File.ReadAllLines(@"Input.txt").Select(line => new Step(line.Split(' ')[0],
                int.Parse(line.Split(' ')[1]))).ToList();

            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (var line in input)
            {
                switch (line.Action)
                {
                    case "forward":
                        horizontal += line.Amount;
                        depth = depth + (aim * line.Amount);
                        break;
                    case "up":
                        aim -= line.Amount;
                        break;
                    case "down":
                        aim += line.Amount;
                        break;
                }
            }
            int answer = horizontal * depth;
            Console.WriteLine($"Horizontal {horizontal} * Depth {depth} equals {answer}");
            return answer;
        }

        public record Step(string Action, int Amount)
        {
            public string Action { get; } = Action;
            public int Amount { get; } = Amount;
        }
    }
}
