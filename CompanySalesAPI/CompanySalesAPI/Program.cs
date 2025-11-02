using CompanySalesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataWarehouseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.ICustomerService, CompanySalesAPI.Services.CustomerService>();
builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.IProductService, CompanySalesAPI.Services.ProductService>();
builder.Services.AddScoped<CompanySalesAPI.Services.Interfaces.ISalesService, CompanySalesAPI.Services.SalesService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
