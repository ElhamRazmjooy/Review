using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Secret Manager
//var password = builder.Configuration["Password"];
//var stringBuilder = new SqlConnectionStringBuilder(builder.Configuration["cs"]);
//stringBuilder.Password = password;
//stringBuilder.UserID = "";
//stringBuilder.InitialCatalog = "";

// Enforce HTTPS
//builder.Services.AddHsts(option =>
//{
//    option.MaxAge = TimeSpan.FromDays(30);
//    option.IncludeSubDomains = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
