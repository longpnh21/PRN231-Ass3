using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        [Required]
        [StringLength(450)]
        public string MemberId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; } = 0;

        public virtual UserDto Member { get; set; }
        public virtual OrderDetailDto OrderDetail { get; set; }
    }
}
