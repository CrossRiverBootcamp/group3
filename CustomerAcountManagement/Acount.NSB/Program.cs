using Acount.NSB;
using CustomerAcountManagement.Storage;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(async (hostContext, services) =>
            {
                 services.AddScoped<IAcountStorage, AcountStorage>();
                Console.Title = "Acount";
                var endpointConfiguration = new EndpointConfiguration("Acount");
                var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
                transport.UseConventionalRoutingTopology(QueueType.Quorum);
                transport.ConnectionString("host = localhost");
                var recoverability = endpointConfiguration.Recoverability();
                recoverability.Immediate(
                    customizations: imeddiate =>
                    imeddiate.NumberOfRetries(1)
                    );
                recoverability.Delayed(
                    customizations: delayed =>
                    {
                        delayed.NumberOfRetries(1);
                    });
                var defaultFactory = LogManager.Use<DefaultFactory>();
                defaultFactory.Level(LogLevel.Info);
                var connection = "Server=localhost;database=NServiceBus;Trusted_Connection=True;";
                var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
                var subscriptions = persistence.SubscriptionSettings();
                //subscriptions.CacheFor(TimeSpan.FromMinutes(1));
                persistence.ConnectionBuilder(
                    connectionBuilder: () =>
                    {
                        return new SqlConnection(connection);
                    });
                var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
                dialect.Schema("NSB");
                endpointConfiguration.EnableInstallers();
                endpointConfiguration.EnableOutbox();
                endpointConfiguration.AuditProcessedMessagesTo("audit");
                endpointConfiguration.SendFailedMessagesTo("error");
                //SubscribeToNotifications.Subscribe(endpointConfiguration);
                var endpointInstance = await Endpoint.Start(endpointConfiguration);
                Console.WriteLine("Please press enter to exit....");
                Console.ReadLine();
                await endpointInstance.Stop();

            });
}