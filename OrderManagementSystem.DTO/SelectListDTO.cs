namespace OrderManagementSystem.DTO
{
    public class SelectListDto
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
        public object Data { get; set; }
    }


    public class SelectChildWithParentDto
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
        public List<SelectListDto> Childs { get; set; }
    }
}
