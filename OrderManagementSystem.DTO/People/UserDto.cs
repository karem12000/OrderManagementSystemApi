namespace OrderManagementSystem.DTO.People
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

    }

    public class EditUserDto : UserDto
    {
        public Guid Id { get; set; }
    }
    public class UserParameters
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UserChangePasswordParameters
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }

}
