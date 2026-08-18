using LoggingSample.Middlewares;
using LoggingSample.Services;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LoggingDb");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new CompactJsonFormatter(),"Logs/app-.log", 
        rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(connectionString: connectionString!, 
        sinkOptions: new MSSqlServerSinkOptions 
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        })
    .CreateLogger();
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<OrderService>();
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

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();
