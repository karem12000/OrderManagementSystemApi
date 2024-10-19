namespace OrderManagementSystem.DTO
{
    public class ResultDto<T>
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; } = "";
        public T Data { get; set; }
    }

    public class ResultDto
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; } = "";
        public object Data { get; set; }
    }
}
