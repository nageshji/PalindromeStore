using PalindromeStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalindromeStore.Contracts
{
    public interface IPalindromeStoreRepository
    {
        Task<IEnumerable<Palindrome>> GetPalindromesAsync();
        Task<Palindrome> GetPalindromeAsync(int id);
        Task<bool> AddPalindromeAsync(Palindrome palidrome);
        Task<bool> DeletePalindromeAsync(int id);       
    }
}