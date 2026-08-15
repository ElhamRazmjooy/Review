using InterceptorSample.Data;
using InterceptorSample.Interceptors;
using InterceptorSample.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<AuditInterceptor>();
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();
    options.UseInMemoryDatabase("AuditDb").AddInterceptors(interceptor);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var user = new User
    {
        Name = "Ali",
        Age = 25
    };
    db.Users.Add(user);
    db.SaveChanges();
    user.Name = "Ali Ahmadi";
    user.Age = 26;
    db.SaveChanges();
    db.Users.Remove(user);
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
