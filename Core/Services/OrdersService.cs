using Core.Domain.Entities;
using Core.Dto.OrderDto;
using Core.Dto.ProductDto;
using Core.Exceptions;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ILogger<OrdersService> _logger;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;

        public OrdersService(ILogger<OrdersService> logger, IOrdersRepository ordersRepository, IProductsRepository productsRepository)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
        }

        // Get all orders from repository
        public async Task<List<OrderResponse>> GetOrdersAsync()
        {
            _logger.LogInformation("GetOrdersAsync method in OrdersService.");

            // Get orders from repository
            List<Order> orders = await _ordersRepository.GetOrdersAsync();

            return orders.Select(o => o.ToOrderResponse()).ToList();
        }

        // Add order, ordered products and ordered product toppings to database
        public async Task<OrderResponse> AddOrderAsync(OrderAddRequest orderAddRequest)
        {
            _logger.LogInformation("AddOrderAsync method in OrdersService.");

            // Parse OrderAddRequest to Order
            Order order = orderAddRequest.ToOrder();

            // Check if products in order exist, if not throw NotFoundException()
            List<Product?> products = [];

            foreach(var orderedProduct in order.OrderedProducts)
            {
                products.Add(await _productsRepository.GetProductByIdAsync(orderedProduct.ProductId));
            }
            if(products.Any(p => p == null))
            {
                throw new NotFoundException($"Product in order not found.");
            }

            // Calculate order total price
            order.TotalPrice = products.Select(p => p!.Price).Sum();

            // Check if ordered product toppings exist in default product, if not remove them
            foreach (OrderedProduct orderedProduct in order.OrderedProducts)
            {
                Product product = products.FirstOrDefault(p => p!.Id == orderedProduct.ProductId)!;
                orderedProduct.Product = product;

                orderedProduct.OrderedProductToppings = CheckToppings(orderedProduct, product!);
            }

            // Try to add order to database
            await _ordersRepository.AddOrderAsync(order);
            // Try to add ordered products to database
            await Task.WhenAll(order.OrderedProducts.Select(op => _ordersRepository.AddOrderedProductAsync(op)));
            // Try to add ordered product toppings to database
            order.OrderedProducts.Select(
                op => Task.WhenAll(op.OrderedProductToppings.Select(
                    opt => _ordersRepository.AddOrderedProductToppingAsync(opt))));

            // If less than (NUM OF ORDERS + NUM OF ORDERED PRODUCTS + NUM OF ORDERED PRODUCT TOPPINGS) are saved, throw FailedSavingException()
            if (await _ordersRepository.HowManySaved() < 1 + order.OrderedProducts.Count + order.OrderedProducts.Select(op => op.OrderedProductToppings).ToList().Count)
            {
                throw new FailedSavingException("Failed to save all changes while adding order to database.");
            }

            return order.ToOrderResponse();
        }

        // Check if toppings in ordered product exist in default product, if not remove them
        private List<OrderedProductTopping> CheckToppings(OrderedProduct orderedProduct, Product product)
        {
            List<OrderedProductTopping> updatedToppings = new List<OrderedProductTopping>();

            foreach (var orderedProductTopping in orderedProduct.OrderedProductToppings)
            {
                if (product.ToppingProducts.Any(p => p.ToppingId == orderedProductTopping.ToppingId))
                {
                    updatedToppings.Add(orderedProductTopping);
                }
            }

            for (int i = 0; i < updatedToppings.Count; i++)
            {
                for (int j = 0; j < updatedToppings.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (updatedToppings[i] == updatedToppings[j])
                    {
                        updatedToppings.RemoveAt(j);
                    }
                }
            }

            return updatedToppings;
        }
    }
}
