namespace DataLayer.Dtos;

public class OrderDto
{
     
        public OrderDto()
        {
            LineItemsDtos = new();
        }

        public int? OrderId { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessing { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerCountry  { get; set; }
        public string AdminUser { get; set; }
        public List<LineItemDto> LineItemsDtos { get; set; }
        public string UniqueId { get; set; }
}