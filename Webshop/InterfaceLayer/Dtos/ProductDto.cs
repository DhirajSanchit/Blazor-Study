namespace InterfaceLayer.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        public string? Brand { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string ImageLink { get; init; }
        public string Description { get; init; }
        public DateTime? ArchiveDate { get; init; }
    }
}