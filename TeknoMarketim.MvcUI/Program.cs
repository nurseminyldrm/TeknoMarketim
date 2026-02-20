using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeknoMarketim.Business;
using TeknoMarketim.Data.Context;
using TeknoMarketim.MvcUI.EmailServices;
using TeknoMarketim.MvcUI.Identity;

namespace TeknoMarketim.MvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddBusinessServices(builder.Configuration);

            builder.Services.AddDbContext<ApplicationIdentityDbContext>(option => 
            option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                //password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;

                //lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //user settings
                options.User.RequireUniqueEmail = true;

                //SignIn settings
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;

            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/AdminLogin";
                options.LogoutPath = "/AdminLogout";
                options.AccessDeniedPath = "/Admin/AccessDenied";
                options.SlidingExpiration = false;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "TeknoMarketim.MvcUI.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x =>
                new SmtpEmailSender(
                    builder.Configuration["EmailSender:Host"] ??"",
                    builder.Configuration.GetValue<int>("EmailSender:Port"),
                    builder.Configuration["EmailSender:UserName"] ?? "",
                    builder.Configuration["EmailSender:Password"] ?? "",
                    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL")
                    
                    
                    )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();


            app.MapControllerRoute(
                name: "Admin",
                pattern: "Admin",
                defaults: new { controller = "AdminLogin", action = "AdminLogin" }

            );

            app.MapControllerRoute(
                name:"adminProducts",
                pattern: "admin/products",
                defaults: new { controller = "Admin", action = "ProductList" }
                );

            app.MapControllerRoute(
                name: "AdminProductEdit",
                pattern: "admin/products/edit/{id?}",
                defaults: new { controller = "Admin", action = "EditProduct" }
                );

            app.MapControllerRoute(
                name: "cart",
                pattern: "cart",
                defaults: new { controller = "Cart", action = "Index" }
                );

            app.MapControllerRoute(
                name: "orders",
                pattern: "orders",
                defaults: new { controller = "Order", action = "GetOrders" }
                );

            app.MapControllerRoute(
                name: "checkout",
                pattern: "checkout",
                defaults: new { controller = "Cart", action = "Checkout" }
                );

            app.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new { controller = "HomePage", action = "ProductList" }
                );

            app.MapControllerRoute(
                name:"default",
                pattern: "{controller=HomePage}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.Run();
        }


    }
}