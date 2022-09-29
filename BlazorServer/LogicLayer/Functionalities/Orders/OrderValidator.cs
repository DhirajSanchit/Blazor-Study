using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class OrderValidator : IOrderValidator
{
    public bool ValidateCustomerInformation(string name, string address, string city, string province, string country)
    { 

        //Check if the customer information is complete, meaning not empty or null.
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(address) ||
            string.IsNullOrWhiteSpace(city) ||
            string.IsNullOrWhiteSpace(province) ||
            string.IsNullOrWhiteSpace(country))
        {
            return false;
        }

        return true;
    }

    public bool ValidateCreateOrder(Order order)
    {
            //Check if order exists
            if (order == null)
            {
                return false;
            }
            
            //Check if order has items
            if (order.LineItems == null || order.LineItems.Count <= 0)
            {
                return false;
            }

            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Price < 0 || item.Quantity <= 0)
                {
                    return false;
                }
            }

            //Check the customer info
            if (!ValidateCustomerInformation(
                    order.CustomerName,
                    order.CustomerAddress,
                    order.CustomerCity,
                    order.CustomerCountry,
                    order.CustomerProvince))
            {
                return false;
            }
            return true;
    }

    public bool ValidateProcessOrder(Order order)
    {
        if (!order.DateProcessed.HasValue ||
            string.IsNullOrWhiteSpace(order.AdminUser))
        {
            return false;
        }
        return true;
    }
    
    public bool ValidateUpdateOrder(Order order)
    {
        //order has to existi
        if (order == null) return false;
        if (!order.OrderId.HasValue) return false;

        //order has to have order line items
        if (order.LineItems == null || order.LineItems.Count <= 0) return false;

        //Placed Date has to be populated
        if (!order.DatePlaced.HasValue) return false;

        //Other dates
        if (order.DateProcessed.HasValue || order.DateProcessing.HasValue) return false;

        //valiate uniqueId
        if (string.IsNullOrWhiteSpace(order.UniqueId)) return false;

        //validating line items
        foreach (var item in order.LineItems)
        {
            if (item.ProductId <= 0 ||
                item.Price < 0 ||
                item.Quantity <= 0 ||
                item.OrderId == order.OrderId) return false;
        }

        //validate customer info
        if (!ValidateCustomerInformation(order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerProvince,
                order.CustomerCountry)) return false;

        return true;
    }
    
     
} 