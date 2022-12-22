using BusinessLogicLayer.Classes;
using Webshop.Models;

namespace Webshop.Helpers.ViewModelHelpers;

public class OrderViewModelHelper
{
    public static OrderViewModel ToOrderViewModel(Order order)
    {
        //create a new product view model from the product
        return new OrderViewModel
        {
            //set the properties of order to the properties of the order view model
            OrderId = order.OrderId,
            FirstName = order.FirstName,
            LastName = order.LastName,
            AddressLine1 = order.AddressLine1,
            AddressLine2 = order.AddressLine2,
            City = order.City,
            State = order.State,
            ZipCode = order.ZipCode,
            Country = order.Country,
            Email = order.Email.ToLower(),
            PhoneNumber = order.PhoneNumber,
            OrderPlaced = order.OrderPlaced,
            UserId = order.UserId,
            OrderTotal = order.OrderTotal,
        };
    }

    public static List<OrderViewModel> ToOrderViewModelList(List<Order> orders)
    {
            //create a new list of order view models
        List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

        //loop through the list of orders
        foreach (Order order in orders)
        {
            //add the order view model to the list
            orderViewModels.Add(ToOrderViewModel(order));
        }

        //return the list of order view models
        return orderViewModels;
    }

    public static Order ToOrder(OrderViewModel orderViewModel)
    {
        //create a new order from the order view model
        return new Order
        {
            //set the properties of the order view model to the properties of the order
            OrderId = orderViewModel.OrderId,
            FirstName = orderViewModel.FirstName,
            LastName = orderViewModel.LastName,
            AddressLine1 = orderViewModel.AddressLine1,
            AddressLine2 = orderViewModel.AddressLine2,
            City = orderViewModel.City,
            State = orderViewModel.State,
            ZipCode = orderViewModel.ZipCode,
            Country = orderViewModel.Country,
            Email = orderViewModel.Email.ToLower(),
            PhoneNumber = orderViewModel.PhoneNumber,
            OrderPlaced = orderViewModel.OrderPlaced,
            UserId = orderViewModel.UserId,
            OrderTotal = orderViewModel.OrderTotal,
        };
    }
   

}