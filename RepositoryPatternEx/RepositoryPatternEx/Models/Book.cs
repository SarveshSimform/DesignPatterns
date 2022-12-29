using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternEx.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
       
     
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
       

       [Required]
        public decimal Price { get; set; }
    }
}