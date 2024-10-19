using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementSystem.BLL.Guide;
using OrderManagementSystem.DAL;
using OrderManagementSystem.DAL.DesignPattern;

namespace OrderManagementSystem.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //#region DAL
            services.AddScoped(typeof(IUnitOfWork<OrderManagementSystemContext>), typeof(UnitOfWork<OrderManagementSystemContext>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //#endregion

            var bllClasses = typeof(ProductBll).Assembly.GetTypes().Where(p => p.IsClass && p.Name.ToLower().Contains("bll"));

            bllClasses.ToList().ForEach(p =>
            {
                services.AddScoped(p);

            });


        }
    }
}
