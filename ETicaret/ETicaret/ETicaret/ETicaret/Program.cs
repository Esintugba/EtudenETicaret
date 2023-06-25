using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ETicaret.Data;
using System.Net;
using ETicaret.Areas.Admin.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ETicaretContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ETicaretContext") ?? throw new InvalidOperationException("AdminUserSecurityAttribute")));

builder.Services.AddScoped<AdminUserSecurityAttribute>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(1800);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Anasayfa}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=GirisController}/{action=Giris}/{id?}"
    );
});

app.Run();
