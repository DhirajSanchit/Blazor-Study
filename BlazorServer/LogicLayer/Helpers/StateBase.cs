using LogicLayer.Interfaces.ShoppingCart;

namespace LogicLayer.Helpers;

public class StateBase : ICartStateHandler
{
    protected Action listeners;
    
    public void AddStateChangeListeners(Action listener) => this.listeners += listener;
    public void RemoveStateChangeListeners(Action listener) => this.listeners -= listener;

    public void BroadcastStateChange()
    {
        if(this.listeners != null) this.listeners.Invoke(); 
    }
}

