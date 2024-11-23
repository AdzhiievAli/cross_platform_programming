using Microsoft.AspNetCore.Http;
using Auth0.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuth0WebAppAuthentication(options =>  
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting(); 

app.UseAuthentication(); 
app.UseAuthorization(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    
    endpoints.MapControllerRoute(
        name: "registration",
        pattern: "registration/index",
        defaults: new { controller = "Registration", action = "Index" });
    
    endpoints.MapControllerRoute(
        name: "lab1",
        pattern: "Lab1",
        defaults: new { controller = "Lab1", action = "Index" });

            endpoints.MapControllerRoute(
        name: "lab2",
        pattern: "Lab2",
        defaults: new { controller = "Lab2", action = "Index" });
        
            endpoints.MapControllerRoute(
        name: "lab3",
        pattern: "Lab3",
        defaults: new { controller = "Lab3", action = "Index" });
});

app.Run();
