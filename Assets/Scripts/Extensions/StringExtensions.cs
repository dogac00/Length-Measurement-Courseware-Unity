using System.Linq;

public static class StringExtensions
{
    public static string RemoveAllWhitespace(this string input)
    {
        return new string(input.Where(c => !char.IsWhiteSpace(c))
                               .ToArray());
    }
}
