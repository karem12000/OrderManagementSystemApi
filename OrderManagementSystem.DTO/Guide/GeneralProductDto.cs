namespace OrderManagementSystem.DTO.Guide
{
    public class GeneralProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long StockQuantity { get; set; }
    }
    public class CreateProductDto : GeneralProductDto
    {
        public Guid OwnerId { get; set; }
    }

    public class UpdateProductDto : GeneralProductDto
    {
        public Guid Id { get; set; }
    }
    public class GetProductDto : GeneralProductDto
    {
        public Guid Id { get; set; }
    }

    public class ProductTableDto : GeneralProductDto
    {
        public Guid ID { get; set; }
        public long RowNum { get; set; }
        public bool IsActive { get; set; }
        public string AddedDate { get; set; }
        public int TotalCount { get; set; }
    }
}
