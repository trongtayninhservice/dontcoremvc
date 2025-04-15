using AdvancedEship.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ConnectDb2;

var builder = WebApplication.CreateBuilder(args);
// Thêm các dịch vụ khác
builder.Services.AddControllersWithViews();

// Thêm dịch vụ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian timeout của session
    options.Cookie.HttpOnly = true; // Chỉ cho phép truy cập session qua HTTP
    options.Cookie.IsEssential = true; // Đánh dấu cookie là cần thiết
});


// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//var connectionString = ConfigurationHelper.GetConnectionString() ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionString = ConnectDb2.ConfigurationHelper.GetConnectionString();
//console.WriteLine(connectionString);
Console.WriteLine(Directory.GetCurrentDirectory() + connectionString);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Kích hoạt middleware session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.MapControllerRoute(
    name: "MyCartCustom",
    pattern: "my_cart.html",
   defaults: new { controller = "Cart", action = "ListCart" }
   
);
app.Run();
