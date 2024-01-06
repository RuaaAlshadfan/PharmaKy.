using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharma_Ky.Areas.Identity.Data;
using Pharma_Ky.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Pharma_KyContextConnection") ?? throw new InvalidOperationException("Connection string 'Pharma_KyContextConnection' not found.");

builder.Services.AddDbContext<Pharma_KyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Pharma_KyUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Pharma_KyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapRazorPages();
app.Run();
