using PalindromeStore.Utilities;


namespace PalindromeStore.Operations
{
    public static class PalindromeOps
    {
        /// <summary>
        /// Gets an input from user and checks to see if it is a palindrome.
        /// </summary>
        public static bool PalindromeTester(string text)
        {
            text = StringUtilities.RemoveSpecialCharacters(text);            

            if (text.Equals(StringUtilities.ReverseString(text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
