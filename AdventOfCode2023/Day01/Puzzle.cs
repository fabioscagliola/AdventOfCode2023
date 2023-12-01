using System.Text.RegularExpressions;

namespace com.fabioscagliola.AdventOfCode2023.Day01;

class Puzzle : ISolvable
{
    public object Solve(string input)
    {
        char[] digits = "1234567890".ToCharArray();

        using StringReader stringReader = new(input);

        int sum = 0;

        string? line;

        while (true)
        {
            line = stringReader.ReadLine();

            if (line == null)
                break;

            string digit1 = line.Substring(line.IndexOfAny(digits), 1);
            string digit2 = line.Substring(line.LastIndexOfAny(digits), 1);

            sum += int.Parse(digit1 + digit2);
        }

        return sum;
    }
}
