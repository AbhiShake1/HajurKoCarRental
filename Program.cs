using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();


/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "__CarRental_";
        options.ExpireTimeSpan = TimeSpan.FromDays(365);
        options.LoginPath = "/Auth/Login";
    });*/

/*app.UseSwagger();*/
/*app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});*/

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
