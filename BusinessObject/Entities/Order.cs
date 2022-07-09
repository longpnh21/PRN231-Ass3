using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entities
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        [StringLength(450)]
        public string MemberId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; } = 0;

        public virtual User Member { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
