using Assignment.DBContextManager;
using Assignment.Mapper;
using Assignment.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Extention
{
    public static class ServiceExtention
    {
        public static  void GetExtentions( this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<ProductAppContext>(s => s.UseSqlServer(configuration.GetConnectionString("ProductDB")));
            service.AddScoped<IProductService,ProductService>();
            service.AddScoped<IAudit, AuditService>();
            service.AddAutoMapper(typeof(MapperProfile));
        }
    }
}
