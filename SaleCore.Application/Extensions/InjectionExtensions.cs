using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleCore.Application.Commons.Ordering;
using SaleCore.Application.Extensions.WatchDog;
using SaleCore.Application.Interfaces;
using SaleCore.Application.Services;
using System.Reflection;


namespace SaleCore.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IOrderingQuery, OrderingQuery>();
            services.AddTransient<IFileStorageLocalApplication, FileStorageLocalApplication>();

            services.AddScoped<IGenerateExcelApplication, GenerateExcelApplication>();
            //services.AddScoped<IGenerateExcelApplication, GenerateExcelApplication>();

            services.AddScoped<AuthApplication, AuthApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IDocumentTypeApplication, DocumentTypeApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IProductStockApplication, ProductStockApplication>();
            services.AddScoped<IProviderApplication, ProviderApplication>();
            services.AddScoped<IPurcharseApplication, PurcharseApplication>();
            services.AddScoped<ISaleApplication, SaleApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IVoucherDocumentTypeApplication, VoucherDocumentTypeApplication>();
            services.AddScoped<IWarehouseApplication, WarehouseApplication>();

            services.AddWatchDog(configuration);

            return services;
        }
    }
}