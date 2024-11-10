using Core.Domain.Entities;
using Core.Dto.ToppingDto;

namespace Core.Dto.ProductDto
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public ProductType? ProductType { get; set; }

        public MeatType? MeatType { get; set; }

        public List<ToppingResponse> Toppings { get; set; } = [];
    }

    public static class ProductExtension
    {
        public static ProductResponse ToProductResponse(this Product? product)
        {
            if (product == null)
                return new ProductResponse();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductType = product.ProductType,
                MeatType = product.MeatType,
                Toppings = product.ToppingProducts.Select(tp => tp.Topping.ToToppingResponse()).ToList()
            };
        }
    }
}
