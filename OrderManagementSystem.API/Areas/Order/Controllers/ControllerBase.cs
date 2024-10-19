using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Common.General;

namespace OrderManagementSystem.Api.Areas.Order.Controllers
{
    [Area(AppConstants.Areas.Order), Route("api/[Area]/[controller]/[Action]")]
    //[Authorize]
    public class ControllerBase : API.Helpers.ControllerBase
    {

    }
}
