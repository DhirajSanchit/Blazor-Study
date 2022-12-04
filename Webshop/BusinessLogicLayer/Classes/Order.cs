using System.ComponentModel.DataAnnotations;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes
{
    public class Order
    {
        // [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")] public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(10)] public string? State { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(
            @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; } = string.Empty;

        // [BindNever]
        public decimal OrderTotal { get; set; }

        // [BindNever]
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