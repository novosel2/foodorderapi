using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice can't be less than 0.")]
        public double TotalPrice { get; set; }

        [Required]
        public string Place { get; set; } = string.Empty;

        public List<OrderedProduct> OrderedProducts { get; set; } = [];
    }
}
