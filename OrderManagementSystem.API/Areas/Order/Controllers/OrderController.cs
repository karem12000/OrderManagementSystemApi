using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.BLL.Order;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.Order;
using ControllerBase = OrderManagementSystem.Api.Areas.Guide.Controllers.ControllerBase;

namespace OrderManagementSystem.API.Areas.Order.Controllers
{
    public class OrderController(OrderBll orderBll) : ControllerBase
    {
        [HttpPost, AllowAnonymous]
        public Task<ResultDto> PlaceOrderAsync(CreateOrderDto data) => orderBll.PlaceOrderAsync(data);

        [HttpPost]
        public Task<ResultDto> GetAllOrdersByOwnerId(Guid id) => orderBll.GetOrdersListByOwnerId(id);

        [HttpPost]
        public Task<ResultDto> AcceptOrder(Guid id) => orderBll.AcceptOrder(id);

        [HttpPost]
        public Task<ResultDto> CancelOrder(Guid id) => orderBll.CancelOrder(id);

        [HttpPost, AllowAnonymous]
        public Task<ResultDto> GetAllOrdersByCustomerEmail(string email) => orderBll.GetOrdersListByCustomerEmail(email);

    }
}
