using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities
{
    public class OrderedProductTopping
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderedProductId { get; set; }

        [Required]
        public Guid ToppingId { get; set; }

        [ForeignKey(nameof(ToppingId))]
        public Topping? Topping { get; set; }

        public static bool operator ==(OrderedProductTopping left, OrderedProductTopping right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrderedProductTopping left, OrderedProductTopping right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            OrderedProductTopping objToCompare = (OrderedProductTopping)obj;

            return ToppingId == objToCompare.ToppingId && OrderedProductId == objToCompare.OrderedProductId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
