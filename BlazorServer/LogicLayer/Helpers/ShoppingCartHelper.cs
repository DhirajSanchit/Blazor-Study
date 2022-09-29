using LogicLayer.Functionalities.ShoppingCart;
using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;

namespace LogicLayer.Helpers;

public class ShoppingCartHelper : StateBase, ICartState 
{
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartHelper(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }
    
    public async Task<int> GetItemsCount()
    {
        var order = await _shoppingCart.GetOrderAsync();
        if (order != null && order.LineItems != null && order.LineItems.Count > 1)
        {
            return order.LineItems.Count;
        }
        //TODO: REVISE NOT TO BE IN FINAL PRODUCT
        return 0;
    }

    
    //When LineItems is updated, broadcast state
    public async void UpdateLineItemsCount()
    {
        base.BroadcastStateChange();
    }

    //When Quantity is updated, broadcast state
    //Also needs to implemented, when Quantity changes, so should lineitems
    public void UpdateProductQuantity()
    {
        base.BroadcastStateChange();
    }
}