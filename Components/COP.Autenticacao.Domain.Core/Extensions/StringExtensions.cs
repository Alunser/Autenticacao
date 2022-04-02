using System.Linq;
using System.Text.RegularExpressions;

namespace COP.Autenticacao.Domain.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsWhiteSpace(this string str)
        {
            var chars = str.ToCharArray();

            return chars.Any(x => char.IsWhiteSpace(x));
        }

        public static bool ContainsNumber(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var chars = str.ToCharArray();

            return chars.Any(x => char.IsDigit(x));
        }

        public static bool ContainsUppercase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return Regex.IsMatch(str, "[A-Z]");
        }

        public static bool ContainsLowercase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return Regex.IsMatch(str, "[a-z]");
        }

        public static bool ContainsSpecialCharacter(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return Regex.IsMatch(str, "[!@#$%^&*()-+]");
        }

        public static bool ContainsRepeatedCharacter(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var chars = str.ToCharArray();

            return chars.GroupBy(g => g).Select(s => new { Character = s.Key, Count = s.Count() }).Where(x => x.Count > 1).Any();
        }
    }
}
