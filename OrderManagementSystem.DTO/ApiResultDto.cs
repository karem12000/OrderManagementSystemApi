using System.Net;

namespace OrderManagementSystem.DTO
{
    internal class ApiResultDto
    {
    }
    public class ApiLogInResponseDto : ApiResponseViewModel<LohInResponse>
    {
        public string Token { get; set; }

        public long UserId { get; set; }
    }
    public class ApiUserResponseDto : ApiResponseViewModel<LohInResponse>
    {

    }
    public class LohInResponse
    {

        public int Status { get; set; } = 1;

        public string Token { get; set; } = "";


        public string Email { get; set; } = "";


        public string Fullname { get; set; } = "";


        public Guid? Id { get; set; }

        public bool IsActive { get; set; }

    }
    public class ApiResponseViewModel<T>
    {
        public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;

        public List<string> Messages { get; set; } = new List<string>();

        public bool Status { get; set; }

        public T Results { get; set; }


    }
}
