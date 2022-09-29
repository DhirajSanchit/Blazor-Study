namespace LogicLayer.Interfaces.ShoppingCart;

public interface ICartState : ICartStateHandler
{
     Task<int> GetItemsCount();
     void UpdateLineItemsCount();
     void UpdateProductQuantity();



}