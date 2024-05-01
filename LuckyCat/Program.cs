using System.Data;
using LuckyCat.Interface;
using LuckyCat.Repositories;
using LuckyCat.Services;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IDbConnection>(_ =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    return new MySqlConnection(connection);
});

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.Run();