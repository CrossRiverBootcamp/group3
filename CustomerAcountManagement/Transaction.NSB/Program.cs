using NServiceBus;
using Microsoft.Extensions.Hosting;
using NServiceBus.Logging;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using NSB.Messages.Commands;

Console.Title = "Transaction.NSB";
var defaultFactory = LogManager.Use<DefaultFactory>();
defaultFactory.Level(LogLevel.Info);

var endpointConfiguration = new EndpointConfiguration("TransactionSaga");
var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
transport.UseConventionalRoutingTopology(QueueType.Quorum);
transport.ConnectionString("host = localhost");
var routing = transport.Routing();
routing.RouteToEndpoint(typeof(TransferMoney), "Acount");
routing.RouteToEndpoint(typeof(UpdateTransactionStatus), "Transaction");



var recoverability = endpointConfiguration.Recoverability();
recoverability.Immediate(
    customizations: imeddiate =>
    imeddiate.NumberOfRetries(2)
    );
recoverability.Delayed(
    customizations: delayed =>
    {
        delayed.NumberOfRetries(2);
    });



var connectionToDB = "Server=localhost;database=NServiceBusTransaction;Trusted_Connection=True;";
var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
var subscriptions = persistence.SubscriptionSettings();
subscriptions.CacheFor(TimeSpan.FromMinutes(1));
var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
persistence.ConnectionBuilder(
    connectionBuilder: () =>
    {
        return new SqlConnection(connectionToDB);
    });

endpointConfiguration.EnableInstallers();
endpointConfiguration.EnableOutbox();
endpointConfiguration.AuditProcessedMessagesTo("audit");
endpointConfiguration.SendFailedMessagesTo("error");
var containerSettings = endpointConfiguration.UseContainer(new DefaultServiceProviderFactory());
containerSettings.ServiceCollection.AddAutoMapper(typeof(Program));

var endpointInstance = await Endpoint.Start(endpointConfiguration);
Console.WriteLine("Please press enter to exit....");
Console.ReadLine();
await endpointInstance.Stop();
