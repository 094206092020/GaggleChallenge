using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.dbo
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [Display(Name = "Product Name")]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string SKU { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }

        [Range(0, 1000)]
        public int Qty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public bool Availability { get; set; }

        [Display(Name = "Product Image")]
        public string ImageUrl { get; set; }
    }
}
