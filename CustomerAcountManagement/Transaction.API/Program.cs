using Serilog;
using Transaction.Service;
using TransactionService;
using NServiceBus;
using System.Data.SqlClient;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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

#region jwt configuration
var securityKey = Encoding.ASCII.GetBytes(configuration["JWT:key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(securityKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

#region swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transaction.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});
#endregion
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

app.UseRouting();

app.UseCors(AllowAll);

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.Run();