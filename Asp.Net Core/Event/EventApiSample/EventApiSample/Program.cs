using EventApiSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<LogService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var userService = app.Services.GetRequiredService<UserService>();
var emailService = app.Services.GetRequiredService<EmailService>();
var logService = app.Services.GetRequiredService<LogService>();

emailService.Subscribe(userService);
logService.Subscribe(userService);
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
