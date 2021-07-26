using EntityFramework_DesignTables.BusinessLogicLayer.Interfaces;
using EntityFramework_DesignTables.BusinessLogicLayer.Services;
using EntityFramework_DesignTables.DataAccessLayer;
using EntityFramework_DesignTables.DataAccessLayer.Interfaces;
using EntityFramework_DesignTables.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Injections
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositoryInjections(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductListRepository, ProductListRepository>();
        }

        public static void AddServiceInjections(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }

        public static void AddUnitOfWorkInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
