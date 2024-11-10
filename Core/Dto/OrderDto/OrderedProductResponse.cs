using Core.Domain.Entities;
using Core.Dto.ProductDto;

namespace Core.Dto.OrderDto
{
    public class OrderedProductResponse
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<string> Toppings { get; set; } = [];
    }

    public static class OrderedProductExtension
    {
        public static OrderedProductResponse ToOrderedProductResponse(this OrderedProduct orderedProduct)
        {
            return new OrderedProductResponse()
            {
                Name = orderedProduct.Product.Name,
                Price = orderedProduct.Product.Price,
                Toppings = orderedProduct.Product.ToProductResponse().Toppings
                .Where(t => orderedProduct.OrderedProductToppings
                .Any(opt => opt.ToppingId == t.Id))
                .Select(t => t.Name).ToList()
            };
        }
    }
}
