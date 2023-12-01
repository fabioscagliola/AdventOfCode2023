using System.Text.RegularExpressions;

namespace com.fabioscagliola.AdventOfCode2023.Day01;

abstract class Puzzle
{
    public static int ParseDigit(string s)
    {
        switch (s)
        {
            case "one":
                return 1;
            case "two":
                return 2;
            case "three":
                return 3;
            case "four":
                return 4;
            case "five":
                return 5;
            case "six":
                return 6;
            case "seven":
                return 7;
            case "eight":
                return 8;
            case "nine":
                return 9;
            default:
                return int.Parse(s);
        }
    }

    protected static object Solve(string input, Regex regex)
    {
        using StringReader stringReader = new(input);

        int sum = 0;

        string? line;

        while (true)
        {
            line = stringReader.ReadLine();

            if (line == null)
                break;

            MatchCollection matches = regex.Matches(line);

            int digit1 = ParseDigit(matches.First().Value);
            int digit2 = ParseDigit(matches.Last().Value);

            sum += int.Parse($"{digit1}{digit2}");
        }

        return sum;
    }
}

class Puzzle1 : Puzzle, ISolvable
{
    public object Solve(string input)
    {
        Regex regex = new(@"\d");
        return Solve(input, regex);
    }
}

class Puzzle2 : Puzzle, ISolvable
{
    public object Solve(string input)
    {
        Regex regex = new(@"\d|one|two|three|four|five|six|seven|eight|nine");
        return Solve(input, regex);
    }
}
