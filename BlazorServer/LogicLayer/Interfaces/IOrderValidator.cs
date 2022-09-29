using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IOrderValidator
{
    public bool ValidateCustomerInformation(string name, string address, string city, string province, string country);
    public bool ValidateCreateOrder(Order order);
    bool ValidateProcessOrder(Order order);
    bool ValidateUpdateOrder(Order order);

}