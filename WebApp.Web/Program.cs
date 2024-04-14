using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApp.Lib.Contexts;
using WebApp.Lib.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Home}/{id?}");
app.MapControllerRoute(
    name: "404",
    pattern: "{*url}",
    defaults: new { controller = "Default", action = "NotFound" }
    );
app.Run();
