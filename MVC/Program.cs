using Application;
using Persistence;
using Common;
using System.Security.Policy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies(builder.Configuration);
builder.Services.AddCommonDependencies();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Landing}/{id?}");
app.MapControllerRoute(
    name: "notFound404",
    pattern: "notFound404",
    defaults: new { controller = "Error", action = "notFound404" });
app.MapControllerRoute(
  name: "profile",
  pattern: "{area=Profile}/{controller=Home}/{action=Dashboard}/{id?}"
);


app.Run();
