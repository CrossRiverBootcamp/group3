using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ttransaction.Storage;
using Ttransaction.Storage.Entities;

namespace TransactionService;
public static class Extensions
{
    public static IServiceCollection AddBLDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITransactionStorage, TransactionStorage>();
        IServiceCollection serviceCollection = services.AddDbContextFactory<TransationDBContext>(opt => opt.UseSqlServer(
          configuration.GetConnectionString("TransactionDB")));
        return services;
    }
}

