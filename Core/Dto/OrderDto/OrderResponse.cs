using Core.Domain.Entities;

namespace Core.Dto.OrderDto
{
    public class OrderResponse
    {
        public string? Place { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderedProductResponse> OrderedProducts { get; set; } = [];
    }

    public static class OrderExtension
    {
        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse()
            {
                Place = order.Place,
                TotalPrice = double.Round(order.TotalPrice, 2, MidpointRounding.AwayFromZero),
                OrderedProducts = order.OrderedProducts.Select(op => op.ToOrderedProductResponse()).ToList()
            };
        }
    }
}
