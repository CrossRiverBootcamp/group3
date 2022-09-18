using Serilog;
using CustomerAcountManagement.Service;
using CustomerAcountManagement.Storage;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
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
IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().
    ReadFrom.Configuration(configuration).
    Enrich.FromLogContext().
    CreateLogger();

var databaseConnection = builder.Configuration.GetConnectionString("BankDB");

var NSBConnection = builder.Configuration.GetConnectionString("NSB");
var queueName = builder.Configuration.GetSection("Queues:AcountAPIQueue:Name").Value;
var rabbitMQConnection = builder.Configuration.GetConnectionString("RabbitMQ");

//builder.Host.UseNServiceBus(hostBuilderContext =>
//{
//    var endpointConfiguration = new EndpointConfiguration("Acount");

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
// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAcountService, AcountService>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton<IEmailVerificationService, EmailVerificationService>();
builder.Services.AddBLDependencies(builder.Configuration);
builder.Services.AddHostedService<CleanVerificationEmailTable>();

builder.Services.AddAutoMapper(System.Reflection.Assembly.Load(typeof(AcountService).Assembly.FullName));
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
