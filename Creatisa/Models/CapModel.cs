using System.ComponentModel.DataAnnotations;

namespace Creatisa.Models;

public class CapModel
{
     public Guid Id { get; set; }  

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Color { get; set; }
        
     
        public string CapSize { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        
        public string Type { get; set; } 
        
        public string Material { get; set; } 
        
        [Required]
        public int Quantity { get; set; } 

}

