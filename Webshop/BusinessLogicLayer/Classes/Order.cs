using System.ComponentModel.DataAnnotations;
using InterfaceLayer.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusinessLogicLayer.Classes
{
    public class Order
    {
        
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
        
        public string FirstName { get; set; } = string.Empty;
          
        public string LastName { get; set; } = string.Empty;
     
        public string AddressLine1 { get; set; } = string.Empty;
 
        public string? AddressLine2 { get; set; }
   
        public string ZipCode { get; set; } = string.Empty;
 
        public string City { get; set; } = string.Empty;

        public string? State { get; set; }
     
        public string Country { get; set; } = string.Empty;
 
        public string PhoneNumber { get; set; } = string.Empty;
 
        public string Email { get; set; } = string.Empty;
 
        public decimal OrderTotal { get; set; }
 
        public DateTime OrderPlaced { get; set; }
        public int? UserId { get; set; }
 
        public Order(List<OrderDetail>? orderDetails, string? addressLine2, string? state,
            decimal orderTotal, DateTime orderPlaced)
        {
            OrderDetails = orderDetails;
            AddressLine2 = addressLine2;
            State = state;
            OrderTotal = orderTotal;
            OrderPlaced = orderPlaced;
        }

        public Order()
        {
        }

        public Order(OrderDto orderDto)
        {
            OrderId = orderDto.OrderId;
            OrderDetails = ConvertToDetailList(orderDto.OrderDetails);
            FirstName = orderDto.FirstName;
            LastName = orderDto.LastName;
            AddressLine1 = orderDto.AddressLine1;
            AddressLine2 = orderDto.AddressLine2;
            ZipCode = orderDto.ZipCode;
            City = orderDto.City;
            State = orderDto.State;
            Country = orderDto.Country;
            PhoneNumber = orderDto.PhoneNumber;
            Email = orderDto.Email;
            OrderTotal = orderDto.OrderTotal;
            OrderPlaced = orderDto.OrderPlaced;
            UserId = orderDto.UserId;
        }

        protected internal OrderDto ToDto()
        {
            return new OrderDto
            {
                OrderDetails = ConvertToDetailDtoList(OrderDetails),
                FirstName = FirstName,
                LastName = LastName,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                ZipCode = ZipCode,
                City = City,
                State = State,
                Country = Country,
                PhoneNumber = PhoneNumber,
                Email = Email,
                OrderTotal = OrderTotal,
                OrderPlaced = OrderPlaced,
                UserId = UserId
            };
        }

        //private method to convert a list of orderdetaildto to a list of orderdetail
        private List<OrderDetail> ConvertToDetailList(List<OrderDetailDto> orderDetailDtos)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var orderDetailDto in orderDetailDtos)
            {
                orderDetails.Add(new OrderDetail(orderDetailDto));
            }

            return orderDetails;
        }

        //private method to convert a list of orderdetail to a list of orderdetaildto
        private List<OrderDetailDto> ConvertToDetailDtoList(List<OrderDetail> orderDetails)
        {
            List<OrderDetailDto> orderDetailDtos = new List<OrderDetailDto>();
            foreach (var orderDetail in orderDetails)
            {
                orderDetailDtos.Add(orderDetail.ToDto());
            }

            return orderDetailDtos;
        }
    }
}