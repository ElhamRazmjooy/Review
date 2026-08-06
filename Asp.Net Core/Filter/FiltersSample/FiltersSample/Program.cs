using FiltersSample.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<ExecutionTimeFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<ValidationFilter>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();
    options.Filters.Add<ExecutionTimeFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<ValidationFilter>();
});
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
