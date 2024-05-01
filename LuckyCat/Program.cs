using LuckyCat.DataBase;
using LuckyCat.Interface;
using LuckyCat.Repositories;
using LuckyCat.Services;
using Microsoft.EntityFrameworkCore;
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


builder.Services.AddDbContext<LuckyDbContext>(options =>
{
    var connectionString = new MySqlConnectionStringBuilder()
    {
        SslMode = MySqlSslMode.None,
        Pooling = true,
        Server = Environment.GetEnvironmentVariable("INSTANCE_UNIX_SOCKET"),
        UserID = Environment.GetEnvironmentVariable("DB_USER"),
        Password = Environment.GetEnvironmentVariable("DB_PASS"),
        Database = Environment.GetEnvironmentVariable("DB_NAME"),
        ConnectionProtocol = MySqlConnectionProtocol.UnixSocket
    }.ToString();

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}, ServiceLifetime.Transient);


var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.Run();