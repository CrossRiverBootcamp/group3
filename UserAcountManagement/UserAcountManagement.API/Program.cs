using UserAcountManagement.Service;
using UserAcountManagement.Storage;
using UserAcountManagement.Storage.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAcountService,AcountService>();
builder.Services.AddScoped<IAcountStorage, AcountStorage>();
builder.Services.AddScoped<IUserStorage, UserStorage>();
builder.Services.AddDbContextFactory<BankDBContext>(opt => opt.UseSqlServer("adf"));
//UserAcountManagement.Service.Extensions.AddBLDependencies(builder.Services);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
