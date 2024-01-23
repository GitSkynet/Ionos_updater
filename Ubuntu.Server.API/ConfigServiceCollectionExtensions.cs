using DataAccess.DataAccess.Interfaces;
using DataAccess.DataAccess.Services;
using Domain.Service.Services;
using DomainService.Contracts;

namespace Ubuntu.Server.API
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IConfiguration>(provider => config);
            services.AddTransient<IDomainContract, DomainBL>();
            services.AddTransient<ICertificateContract, CertificateBL>();
            services.AddTransient<IDomain, DomainDA>();
            services.AddTransient<ICertificate, CertificateDA>();
            services.AddSingleton<DomainBL>();
            services.AddSingleton<DomainDA>();
            services.AddSingleton<CertificateBL>();
            services.AddSingleton<CertificateDA>();
            // services.AddTransient<OpenBooksDbContext>();
            // services.AddDbContext<DbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            // services.AddTransient<IOpenBooksAssociationRepo, OpenBooksAssociationRepo>();
            // services.AddAutoMapper(typeof(SubCategoriesDBtoSubCategoriesDTO).GetTypeInfo().Assembly);

            return services;
        }
    }
}

