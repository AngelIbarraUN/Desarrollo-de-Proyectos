using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Creatisa.Identity
{
    public class Shirt
    {
        public Guid Id { get; set; }  

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Color { get; set; }
        
        [Required]
        public string ShirtSize { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        
        public string Type { get; set; } 
        
        public string Material { get; set; } 
        
        [Required]
        public int Quantity { get; set; }
    }
}