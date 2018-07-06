using Microsoft.EntityFrameworkCore;
using PalindromeStore.Contracts;
using PalindromeStore.Entities;
using PalindromeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalindromeStore.Repositories
{
    public class PalindromeStoreRepository : IPalindromeStoreRepository
    {
        private PalindromeStoreContext _context;
        public PalindromeStoreRepository(PalindromeStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Palindrome>> GetPalindromesAsync()
        {
            return await _context.Palindrome.ToListAsync(); 
        }
        public async Task<bool> AddPalindromeAsync(Palindrome palindrome)
        {
            _context.Add(palindrome);
            return await Save();            
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<bool> DeletePalindromeAsync(int id)
        {
            var palindrome = await _context.Palindrome.SingleOrDefaultAsync(m => m.Id == id);
            _context.Palindrome.Remove(palindrome);
            return await Save();
        }

        public async Task<Palindrome> GetPalindromeAsync(int id)
        {
            return await _context.Palindrome
               .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
