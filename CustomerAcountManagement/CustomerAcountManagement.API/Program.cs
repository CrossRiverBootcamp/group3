using Serilog;
using CustomerAcountManagement.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
IConfigurationRoot configuration = new
            ConfigurationBuilder().AddJsonFile("appsettings.json",
            optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().
    ReadFrom.Configuration(configuration).
    Enrich.FromLogContext().
    CreateLogger();
// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAcountService, AcountService>();
builder.Services.AddBLDependencies(builder.Configuration);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
