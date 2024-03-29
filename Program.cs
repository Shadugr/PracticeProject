using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Data.Entities;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PracticeProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PracticeProjectDbContextConnection' not found.");

builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ProjectDbContext>();



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

//ProjectDbContext projectDbContext = new ProjectDbContext();
//projectDbContext.Identity();

app.Run();
