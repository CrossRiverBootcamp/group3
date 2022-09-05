using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAcountManagement.Storage;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public static class Extensions
{
    public static IServiceCollection AddBLDependencies(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IUserStorage, UserStorage>();
        services.AddScoped<IAcountStorage, AcountStorage>();
        IServiceCollection serviceCollection = services.AddDbContextFactory<BankDBContext>(opt => opt.UseSqlServer(
          configuration.GetConnectionString("BankDB")));
          return services;
    }
}
