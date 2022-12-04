namespace InterfaceLayer.Dtos
{
    public record OrderDto
    {
        public int OrderId { get; set; }
        public List<OrderDetailDto>? OrderDetails { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string AddressLine1 { get; init; }
        public string? AddressLine2 { get; init; }
        public string ZipCode { get; init; }
        public string City { get; init; }
        public string? State { get; init; }
        public string Country { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public decimal OrderTotal { get; init; }
        public DateTime OrderPlaced { get; init; }
        public int? UserId { get; init; }
        
    }
}