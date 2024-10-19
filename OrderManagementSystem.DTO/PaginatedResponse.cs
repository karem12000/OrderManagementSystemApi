namespace OrderManagementSystem.DTO
{
    public class PaginatedResponse
    {
    }

    public class PaginatedResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class PaginatedDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Search { get; set; }
        public Guid? OwnerId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool isGetAll { get; set; }
    }
}
