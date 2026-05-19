using Microsoft.EntityFrameworkCore;
using Laba4.Data;


var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
var config = configBuilder.Build();
var dbConnectionString = config.GetConnectionString("default");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NoteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}")
     .WithStaticAssets();

app.Run();