using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IViewOrderConfirmation
{
    Order Execute(string uniqueId);
}