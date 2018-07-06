using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PalindromeStore.Entities;

namespace PalindromeStore.Models
{
    public class PalindromeStoreContext : DbContext
    {
        public PalindromeStoreContext (DbContextOptions<PalindromeStoreContext> options)
            : base(options)
        {
           Database.Migrate();
        }

        public DbSet<PalindromeStore.Entities.Palindrome> Palindrome { get; set; }
    }
}
