using System.Security.Claims;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;

namespace BusinessLogicLayer.Containers
{
    public class OrderContainer : IOrderContainer
    {
        // private readonly dal dal
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderDAL _orderDAL;

        public OrderContainer(IShoppingCart shoppingCart, IOrderDAL orderDal)
        {
            _shoppingCart = shoppingCart;
            _orderDAL = orderDal;
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                order.OrderPlaced = DateTime.Now;

                List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
                order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

                order.OrderDetails = new List<OrderDetail>();

                foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        Amount = shoppingCartItem.Amount,
                        ProductId = shoppingCartItem.Product.ProductId,
                        Price = shoppingCartItem.Product.Price
                    };

                    order.OrderDetails.Add(orderDetail);
                }

                var result = _orderDAL.CreateOrder(order.ToDto());
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrderContainer.CreateOrder: {ex.Message}");
                throw;
            }
        }
        
    }
}