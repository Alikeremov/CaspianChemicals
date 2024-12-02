using CaspianChemichalsWebAPI.Contexts;
using CaspianChemichalsWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaspianChemichalsWebAPI.Abstraction.Repostories.Generic;
using CaspianChemichalsWebAPI.Abstraction.Repostories;
using CaspianChemichalsWebAPI.Implementations.Repostories;

namespace CaspianChemichalsWebAPI.ServicesRegistrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>().GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));
            //Registrations of Repositories
            services.AddScoped<IAboutRepo, AboutRepo>();
            services.AddScoped<IAboutTranslateRepo, AboutTranslateRepo>();
            services.AddScoped<IOurPartnerRepo, OurPartnerRepo>();
            services.AddScoped<IOurPartnerTranslateRepo, OurPartnerTranslateRepo>();
            services.AddScoped<ISliderRepo, SliderRepo>();
            services.AddScoped<ISliderTranslateRepo, SliderTranslatedRepo>();
            return services;
        }
    }
}
