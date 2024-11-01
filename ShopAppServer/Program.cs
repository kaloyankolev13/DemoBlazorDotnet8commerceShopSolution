using Microsoft.EntityFrameworkCore;
using PhoneShopSharedLibrary.Contract;
using PhoneShopSharedLibrary.Models;
using ShopAppServer.Data;
using ShopAppServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Starting
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Comnections string not found"));
});
builder.Services.AddScoped<IProduct, ProductRepository>();


//Ending

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}


app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseAuthorization();
app.UseStaticFiles();

app.MapRazorPages();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
