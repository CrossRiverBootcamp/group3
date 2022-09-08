using Serilog;
using Transaction.Service;
using TransactionService;
using NServiceBus;


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

#region NServiceBus configuration
builder.Host.UseNServiceBus(hostBuilderContext =>
{
    var endpointConfiguration = new EndpointConfiguration("Transaction");
    var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
    transport.ConnectionString(builder.Configuration.GetConnectionString("RabbitMQ"));
    transport.UseConventionalRoutingTopology(QueueType.Quorum);
    endpointConfiguration.SendOnly();
    var connectionToDB = builder.Configuration.GetConnectionString("TransactionNSB");
    endpointConfiguration.AuditProcessedMessagesTo("audit");
    endpointConfiguration.SendFailedMessagesTo("error");
    return endpointConfiguration;
});
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

