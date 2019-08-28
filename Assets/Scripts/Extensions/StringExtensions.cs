using System.Data;
using System.Linq;

public static class StringExtensions
{
    public static string RemoveAllWhitespace(this string input)
    {
        return new string(input.Where(c => !char.IsWhiteSpace(c))
                               .ToArray());
    }

    public static int GetLastTwoDigit(this string input)
    {
        int result = 0, length = input.Length;
        char last = input[length - 1], beforeLast = input[length - 2];

        if (char.IsDigit(last)) result += last - '0';

        if (char.IsDigit(beforeLast)) result += (beforeLast - '0') * 10;

        return result;
    }
}
