namespace LogicLayer.Interfaces.ShoppingCart;

public interface ICartStateHandler
{
    void AddStateChangeListeners(Action listener);
    void RemoveStateChangeListeners(Action listener);
    void BroadcastStateChange();
     
}