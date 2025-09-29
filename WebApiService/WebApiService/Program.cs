using Microsoft.EntityFrameworkCore;
using WebApiService.Models.Context;
using WebApiService.Repositories.Customer;
using WebApiService.Repositories.Employee;
using WebApiService.Repositories.Order;
using WebApiService.Repositories.Product;
using WebApiService.Repositories.Shipper;
using WebApiService.Services.Employee;
using WebApiService.Services.Order;
using WebApiService.Services.Product;
using WebApiService.Services.Shipper;

var builder = WebApplication.CreateBuilder(args);
var conexion = builder.Configuration.GetConnectionString("StoreConexion");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(conexion));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IShipperService, ShipperService>();
builder.Services.AddTransient<IShipperRepository, ShipperRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
