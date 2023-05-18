using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Areas.Identity.Data;
using PracticeProject.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PracticeProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PracticeProjectDbContextConnection' not found.");

builder.Services.AddDbContext<PracticeProjectDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PracticeProjectUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PracticeProjectDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

//For Identity
app.MapRazorPages();

app.Run();
