using LuckyCat.DataBase;
using LuckyCat.Interface;
using LuckyCat.Repositories;
using LuckyCat.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();


builder.Services.AddDbContext<LuckyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySql");
    connectionString = connectionString!.Replace("${DB_NAME}", Environment.GetEnvironmentVariables()["DB_NAME"]!.ToString());
    connectionString = connectionString!.Replace("${DB_PASS}", Environment.GetEnvironmentVariables()["DB_PASS"]!.ToString());
    connectionString = connectionString!.Replace("${DB_USER}", Environment.GetEnvironmentVariables()["DB_USER"]!.ToString());
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}, ServiceLifetime.Transient);


var app = builder.Build();
app.MapGet("hello", () => "Hello World!");
app.MapControllers();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.Run();