﻿using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleCore.Infrastructure.FileExcel;
using SaleCore.Infrastructure.FilePdf;
using SaleCore.Infrastructure.FileStorage;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;
using SaleCore.Infrastructure.Persistences.Repositories;

namespace SaleCore.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(SaleCoreContext).Assembly.FullName;

            services.AddDbContext<SaleCoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IFileStorageLocal, FileStorageLocal>();
            services.AddTransient<IGenerateExcel, GenerateExcel>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddTransient<IGeneratePdf, GeneratePdf>();

            return services;
        }
    }
}