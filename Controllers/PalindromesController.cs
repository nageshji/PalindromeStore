using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PalindromeStore.Contracts;
using PalindromeStore.Entities;
using PalindromeStore.Models;
using PalindromeStore.Operations;

namespace PalindromeStore.Controllers
{
    public class PalindromesController : Controller
    {
        //private readonly PalindromeStoreContext _context;
        private IPalindromeStoreRepository _palindromeStoreRepository;
        private ILogger<PalindromesController> _logger;

        public PalindromesController(IPalindromeStoreRepository palindromeStoreRepository,
                                     ILogger<PalindromesController> logger)
        {
            //_context = context;
            _palindromeStoreRepository = palindromeStoreRepository;
            _logger = logger;
        }

        // GET: Palindromes
        public async Task<IActionResult> Index()
        {
            return View(await _palindromeStoreRepository.GetPalindromesAsync());
        }

       
        // GET: Palindromes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Palindromes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text")] Palindrome palindrome)
        {
            if (ModelState.IsValid)
            {
               bool isValidPalindrome = PalindromeOps.PalindromeTester(palindrome.Text);
               if(isValidPalindrome)
                {
                    if (await _palindromeStoreRepository.AddPalindromeAsync(palindrome))
                    {
                        _logger.LogInformation("New Palindrome " + palindrome.Text + "is added to the store");
                        ModelState.AddModelError("PalindromeCreate", "Given string is not a Palindrome");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogError("Error in adding new Palindrome " + palindrome.Text);
                    }
                }
               else
                {
                    ModelState.AddModelError("NotPalindrome", "Given string is not a Palindrome");
                }               
               
            }
            return View(palindrome);
        }       

        // GET: Palindromes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var palindrome = await _palindromeStoreRepository.GetPalindromeAsync(id);
            if (palindrome == null)
            {
                return NotFound();
            }

            return View(palindrome);
        }

        // POST: Palindromes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _palindromeStoreRepository.DeletePalindromeAsync(id))
            {
                _logger.LogInformation("Palindrome is removed to the store with Id" + id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogError("Error in deleting Palindrome with id " + id);
                return RedirectToAction(nameof(Delete), id);               
            }
        }
    }
}
