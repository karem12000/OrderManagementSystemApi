using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Common.General;

namespace OrderManagementSystem.Api.Areas.Guide.Controllers
{
    [Area(AppConstants.Areas.Guide), Route("api/[Area]/[controller]/[Action]")]
    [Authorize]
    public class ControllerBase : API.Helpers.ControllerBase
    {

    }
}
