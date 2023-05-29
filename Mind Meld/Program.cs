using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBContextMindMeldConnection") ?? throw new InvalidOperationException("Connection string 'DBContextMindMeldConnection' not found.");

builder.Services.AddDbContext<DBContextMindMeld>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MindMeldUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DBContextMindMeld>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
