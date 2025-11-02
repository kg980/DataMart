using System.Text.Json.Serialization;
using CompanySalesAPI.Data;
using CompanySalesAPI.Repositories;
using CompanySalesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataWarehouseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.ICustomerService, CompanySalesAPI.Services.CustomerService>();
builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.IProductService, CompanySalesAPI.Services.ProductService>();
builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.ISalesService, CompanySalesAPI.Services.SalesService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "CompanySalesAPI is running.");

app.Run();
