using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Api.Authentication;
using OrderManagementSystem.BLL.Guide;
using OrderManagementSystem.BLL.People;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.People;

namespace OrderManagementSystem.API.Areas.People.Controllers
{

    public class CustomerController(CustomerBll customerBll, UserBll userBll, IJwtAuthentication jwtAuthentication) : Api.Areas.People.Controllers.ControllerBase
    {

        [HttpGet]
        public GetCustomerDto GetCustomerById(Guid id) => customerBll.GetById(id);

        [HttpGet]
        public IEnumerable<SelectListDto> GetCustomerSelect() => customerBll.GetCustomerSelect();

        [HttpPost]
        public Task<PaginatedResponse<GetCustomerDto>> GetAllCustomers(PaginatedDto data) => customerBll.GetAllCustomers(data);


        [HttpPost]
        public ResultDto SaveCustomer([FromBody] CreateCustomerDto data) => customerBll.CreateCustomer(data);

        [HttpPost]
        public ResultDto UpdateCustomer(UpdateCustomerDto data) => customerBll.UpdateCustomer(data);

        [HttpPost]
        public ResultDto DeleteCustomer(Guid id) => customerBll.Delete(id);

        [HttpPost, AllowAnonymous]
        public IActionResult Login([FromBody] UserParameters mdl)
        {
            // user already authorized  
            if (User.Identity.IsAuthenticated) Ok();


            var response = userBll.FindByEmailApi(mdl);
            if (response.Status)
            {
                response.Results.Token = jwtAuthentication.Authenticate(response.Results.Id + "");
                return StatusCode(200, response);
            }
            else return StatusCode(200, response);
        }
    }
}
