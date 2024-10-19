using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.BLL.Guide;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.Guide;
using OrderManagementSystem.Tables.Guide;
using ControllerBase = OrderManagementSystem.Api.Areas.Guide.Controllers.ControllerBase;

namespace OrderManagementSystem.API.Areas.Guide.Controllers
{
    public class ProductController(ProductBll productBll) : ControllerBase
    {

        [HttpGet]
        public ResultDto<GetProductDto> GetProductById(Guid id) => productBll.GetById(id);


        [HttpPost]
        public ResultDto CreateProduct(CreateProductDto data) => productBll.CreateProduct(data);

        [AllowAnonymous]
        [HttpPost]
        public Task<PaginatedResponse<Product>> GetAllProducts(PaginatedDto data) => productBll.GetProducts(data);

        [HttpPost]
        public ResultDto UpdateProduct(UpdateProductDto data) => productBll.UpdateProduct(data);

        [HttpPost]
        public ResultDto DeleteProduct(Guid id) => productBll.Delete(id);

    }




}
