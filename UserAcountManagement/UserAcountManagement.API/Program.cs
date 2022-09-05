using Serilog;
using UserAcountManagement.Service;

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

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAcountService,AcountService>();
builder.Services.AddScoped<IAcountStorage, AcountStorage>();
builder.Services.AddScoped<IUserStorage, UserStorage>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContextFactory<BankDBContext>(opt => opt.UseSqlServer("adf"));
//UserAcountManagement.Service.Extensions.AddBLDependencies(builder.Services);
builder.Services.AddScoped<IAcountService, AcountService>();
builder.Services.AddBLDependencies(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
