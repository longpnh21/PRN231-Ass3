using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
