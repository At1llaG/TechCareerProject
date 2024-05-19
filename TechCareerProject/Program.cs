using Microsoft.EntityFrameworkCore;
using TechCareerProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TechCareer.Website.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//string connString = "User Id=sys;Password=A4Atilla;Data Source=//172.233.40.116:1521/free;DBA Privilege=SYSDBA";
//builder.Services.AddDbContext<TechCareerDbContext>(options =>
//    options.UseOracle(connString)
//);

builder.Services.AddDbContext<TechCareerDbContext>(options =>
    options.UseInMemoryDatabase("TechCareerDb")
);

// MinioService
builder.Services.AddSingleton<MinioService>();

var app = builder.Build();



// add data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TechCareerDbContext>();
    context.Database.EnsureCreated();
    context.Products.AddRange(
        new Product { Name = "Product 1", Description = "Description 1", Price = 10.99m, ImageUrl = "https://via.placeholder.com/150" },
        new Product { Name = "Product 2", Description = "Description 2", Price = 20.99m, ImageUrl = "https://via.placeholder.com/150" },
        new Product { Name = "Product 3", Description = "Description 3", Price = 30.99m, ImageUrl = "https://via.placeholder.com/150" }
    );
    context.SaveChanges();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=Index}/{id?}");

app.Run();




