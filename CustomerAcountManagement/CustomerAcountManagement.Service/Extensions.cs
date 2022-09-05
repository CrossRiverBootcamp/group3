using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;
public static class Extensions
{
    public static IServiceCollection AddBLDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerStorage, CustomerStorage>();
        services.AddScoped<IAcountStorage, AcountStorage>();
        IServiceCollection serviceCollection = services.AddDbContextFactory<BankDBContext>(opt => opt.UseSqlServer(
          configuration.GetConnectionString("BankDB")));
        return services;
    }
}

