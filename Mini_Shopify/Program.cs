using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mini_Shopify;
using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultPgConnection"));
});
// Add services to the container.
Log.Logger = (Serilog.ILogger)new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.File("log/villaLogs.txt",rollingInterval:RollingInterval.Day).CreateBootstrapLogger();
builder.Services.ConfigureRepositoryWrapper();
builder.Host.UseSerilog(); 
builder.Services.AddControllers(option =>
{

    option.ReturnHttpNotAcceptable = true;
    option.RespectBrowserAcceptHeader = true;
}).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
