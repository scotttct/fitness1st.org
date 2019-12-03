using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness1stMVCWeb.Models
{
    public class Compendium
    {
        
            [Key]
            public int Id { get; set; }
            [Required]
            public int CategoryId { get; set; }
            [Required]
            public string Category { get; set; }
            [Required]
            public int Codes { get; set; }
            
            [Required]
            public decimal METs { get; set; }
            [Required]
            public string Description { get; set; }
        
    }
}
