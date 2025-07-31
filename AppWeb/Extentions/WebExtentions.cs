using AppData.Context;
using AppEntity.Entities;
using AppService.Describer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Extentions
{
    public static class WebExtentions
    {
        public static IServiceCollection AddWebExtentions(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(30);

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                   context.Response.StatusCode = 404;
                   context.Response.Redirect("/ErrorPage/Index");
                   return Task.CompletedTask;
                };
            });
            services.AddAuthorization();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
            }).AddErrorDescriber<UserIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Logout/Index";
                options.AccessDeniedPath = new PathString("/ErrorPage/Index");
             

            });

            return services;
        }
        
    }
}
