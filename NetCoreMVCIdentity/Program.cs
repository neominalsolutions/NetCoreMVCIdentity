using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCIdentity.Areas.Identity.Data;
using NetCoreMVCIdentity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NetCoreMVCIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'NetCoreMVCIdentityContextConnection' not found.");

builder.Services.AddDbContext<NetCoreMVCIdentityContext>(options =>
    options.UseSqlServer(connectionString));;

//builder.Services.AddDefaultIdentity<NetCoreMVCIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<NetCoreMVCIdentityContext>();;



builder.Services.AddIdentity<NetCoreMVCIdentityUser, IdentityUserRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NetCoreMVCIdentityContext>(); ;

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
