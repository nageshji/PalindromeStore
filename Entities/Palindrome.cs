using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PalindromeStore.Entities
{
    public class Palindrome
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [MaxLength(200)]
        [DisplayName("Palindrome Text"), Required(ErrorMessage = "Palindrome Text is required"), ]
        public string Text { get; set; }
    }
}
