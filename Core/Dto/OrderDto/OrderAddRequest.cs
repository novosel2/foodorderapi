using Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.OrderDto
{
    public class OrderAddRequest
    {
        [Required(ErrorMessage = "Place is required.")]
        public string Place { get; set; } = string.Empty;

        [Required(ErrorMessage = "OrderedProductsAndToppings is required.")]
        public Dictionary<Guid, List<Guid>> ProductsAndToppingsIds { get; set; } = [];

        public Order ToOrder()
        {
            Guid orderId = Guid.NewGuid();

            return new Order()
            {
                Id = orderId,
                DateAndTimeOfOrder = DateTime.Now,
                Place = Place,
                OrderedProducts = GetOrderedProducts(ProductsAndToppingsIds, orderId)
            };
        }

        // Get all ordered products from the dictionary
        private List<OrderedProduct> GetOrderedProducts(Dictionary<Guid, List<Guid>> ProductsAndToppingsIds, Guid orderId)
        {
            List<OrderedProduct> orderedProducts = new List<OrderedProduct>();

            foreach(var key in ProductsAndToppingsIds.Keys)
            {
                Guid orderedProductId = Guid.NewGuid();

                orderedProducts.Add(new OrderedProduct()
                {
                    Id = orderedProductId,
                    OrderId = orderId,
                    ProductId = key,
                    OrderedProductToppings = GetOrderedProductToppings(ProductsAndToppingsIds[key], orderedProductId)
                });
            }

            return orderedProducts;
        }

        // Get all ordered product toppings for orderedproduct from dictionary
        private List<OrderedProductTopping> GetOrderedProductToppings(List<Guid> toppingIds, Guid orderedProductId)
        {
            List<OrderedProductTopping> orderedProductToppings = new List<OrderedProductTopping>();

            foreach(var toppingId in toppingIds)
            {
                orderedProductToppings.Add(new OrderedProductTopping()
                {
                    Id = Guid.NewGuid(),
                    OrderedProductId = orderedProductId,
                    ToppingId = toppingId
                });
            }

            return orderedProductToppings;
        }
    }
}
