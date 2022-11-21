using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; } = default!;
        public Order Order { get; set; } = default!;

        public OrderDetail(int orderId, int productId, int amount, decimal price, Product product, Order order)
        { 
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Price = price;
            Product = product;
            Order = order;
        }

        public OrderDetail()
        {
        }
        
        protected internal OrderDetail(OrderDetailDto dto)
        {
            OrderDetailId = dto.OrderDetailId;
            OrderId = dto.OrderId;
            ProductId = dto.ProductId;
            Amount = dto.Amount;
            Price = dto.Price;
            Product = new Product(dto.Product);
            Order = new Order(dto.Order);
        }
        
        protected internal OrderDetailDto ToDto()
        {
            return new OrderDetailDto
            {
                ProductId = ProductId,
                Amount = Amount,
                Price = Price,
            };
        }
    }
    
    
}
