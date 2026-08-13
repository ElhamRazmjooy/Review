using BackgroundServiceSample.Data;
using BackgroundServiceSample.Models;
using BackgroundServiceSample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BackgroundServiceDb"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHostedService<UserCleanupService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Users.AddRange(
        new User
        {
            Name = "Ali",
            IsActive = true
        },
        new User
        {
            Name = "Sara",
            IsActive = false
        },
        new User
        {
            Name = "Reza",
            IsActive = true
        });
    db.SaveChanges();
}
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
