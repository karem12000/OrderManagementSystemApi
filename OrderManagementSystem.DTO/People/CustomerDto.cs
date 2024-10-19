namespace OrderManagementSystem.DTO.People
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateCustomerDto : CustomerDto
    {

    }
    public class GetCustomerDto : CustomerDto
    {
        public Guid Id { get; set; }
        public string? DateOfBirthStr { get; set; }

    }
    public class UpdateCustomerDto : CustomerDto
    {
        public Guid Id { get; set; }
    }
}
