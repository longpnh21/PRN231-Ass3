using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public string Weight { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int UnitsInStock { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public virtual CategoryDto Category { get; set; }
    }
}
