using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Common.General;

namespace OrderManagementSystem.Api.Areas.People.Controllers
{
    [Area(AppConstants.Areas.People), Route("api/[Area]/[controller]/[Action]")]
    [Authorize]
    public class ControllerBase : API.Helpers.ControllerBase
    {

    }
}
