using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class PlaceOrder : IPlaceOrder
{
     private readonly IOrderValidator _orderValidator;
     private readonly IShoppingCart _shoppingCart;
     private readonly IOrderContainer _orderContainer;
     private readonly ICartState _cartState;

     public PlaceOrder(IOrderValidator orderValidator, IShoppingCart shoppingCart, IOrderContainer orderContainer, ICartState cartState)
     {
          _orderValidator = orderValidator;
          _shoppingCart = shoppingCart;
          _orderContainer = orderContainer;
          _cartState = cartState;
     }

     public async Task<string> Execute(Order order)
     {            
          await _shoppingCart.UpdateOrderAsync(order);
          if (_orderValidator.ValidateCreateOrder(order))
          {
               order.DatePlaced = DateTime.Now;
               order.UniqueId = Guid.NewGuid().ToString();
               int orderId = _orderContainer.CreateOrder(order);
               order = _orderContainer.GetOrder(orderId);

               await _shoppingCart.EmptyCartAsync();
               _cartState.UpdateLineItemsCount();

               return order.UniqueId;
          }            

          return null; 
     }
}