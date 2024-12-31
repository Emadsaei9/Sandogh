using Microsoft.EntityFrameworkCore;
using Sandogh.context;
using Sandogh.Models;

var builder = WebApplication.CreateBuilder(args);

// تنظیمات DbContext برای اتصال به دیتابیس
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // اتصال به دیتابیس

builder.Services.AddControllersWithViews();

var app = builder.Build();

// تنظیمات مربوط به درخواست‌ها
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
