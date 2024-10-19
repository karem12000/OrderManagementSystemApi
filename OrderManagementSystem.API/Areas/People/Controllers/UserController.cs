using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.BLL.Guide;
using OrderManagementSystem.BLL.People;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.People;
using OrderManagementSystem.Tables.People;

namespace OrderManagementSystem.API.Areas.People.Controllers
{

    public class UserController(UserBll userBll) : Api.Areas.People.Controllers.ControllerBase
    {
        [HttpGet]
        public ResultDto<UserDto> GetUserById(Guid id) => userBll.GetById(id);

        [HttpPost]
        public ResultDto SaveUser(UserDto data) => userBll.SaveUser(data);

        [HttpPost]
        public ResultDto EditUser(EditUserDto data) => userBll.EditUser(data);

        [HttpPost]
        public ResultDto ChangePassword(UserChangePasswordParameters data) => userBll.ChangePassword(data);

        [AllowAnonymous]
        [HttpPost]
        public Task<PaginatedResponse<User>> GetAllUsers(PaginatedDto data) => userBll.GetUsers(data);



    }
}
