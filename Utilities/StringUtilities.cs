using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalindromeStore.Utilities
{
    public static class StringUtilities
    {
        /// <summary>
        /// Receives string and returns the string with its letters reversed.
        /// </summary>
        public static string ReverseString(string text)
        {
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string RemoveSpecialCharacters(string text)
        {
            string pattern = @"[^0-9a-zA-Z]";
            return Regex.Replace(text.ToLower(), pattern, String.Empty);
        }
    }
}
