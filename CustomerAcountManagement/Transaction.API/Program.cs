using Serilog;
using Transaction.Service;
using TransactionService;
using NServiceBus;
using System.Data.SqlClient;

IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();
var builder = WebApplication.CreateBuilder(args);

#region add cors policy
string AllowAll = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAll
                      , policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();

                      });
});
#endregion

#region SerilogConfiguration
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration().
    ReadFrom.Configuration(configuration).
    Enrich.FromLogContext().
    CreateLogger();
#endregion

#region NServiceBus configurations
//var databaseConnection = builder.Configuration.GetConnectionString("TransactionNSB");

//var NSBConnection = builder.Configuration.GetConnectionString("NSB");
//var queueName = builder.Configuration.GetSection("Queues:AcountAPIQueue:Name").Value;
//var rabbitMQConnection = builder.Configuration.GetConnectionString("RabbitMQ");

//builder.Host.UseNServiceBus(hostBuilderContext =>
//{
//    var endpointConfiguration = new EndpointConfiguration("Transaction");

//    endpointConfiguration.EnableInstallers();
//    endpointConfiguration.EnableOutbox();

//    var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
//    persistence.ConnectionBuilder(
//    connectionBuilder: () =>
//    {
//        return new SqlConnection(NSBConnection);
//    });

//    var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();

//    var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
//    transport.ConnectionString(rabbitMQConnection);
//    transport.UseConventionalRoutingTopology(QueueType.Quorum);

//    var conventions = endpointConfiguration.Conventions();
//    //conventions.DefiningEventsAs(type => type.Namespace == "NSB.Messages.Events");
//    //conventions.DefiningCommandsAs(type => type.Namespace == "NSB.Messages.Commands");
//    return endpointConfiguration;
//});
#endregion

// Add services to the container.

builder.Services.AddSwaggerGen();

IServiceCollection serviceCollection = builder.Services.AddScoped<ITransactionService, Transaction.Service.TransactionService>();
builder.Services.AddBLDependencies(builder.Configuration);


builder.Services.AddAutoMapper(System.Reflection.Assembly.Load(typeof(Transaction.Service.TransactionService).Assembly.FullName));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseEventHandlerMiddleware();

app.UseCors(AllowAll);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();