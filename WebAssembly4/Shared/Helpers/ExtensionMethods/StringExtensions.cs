using System.Text.RegularExpressions;

namespace TaskEvidence.Shared.Helpers.ExtensionMethods.Strings
{
    public static class StringExtensions
    {
        public static string Shorten(this string str, int number)
        {
            return str = str.Length <= number ? str : str.Substring(0, number) + "...";
        }
    }
}
