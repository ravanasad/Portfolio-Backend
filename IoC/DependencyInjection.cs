using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services,IConfiguration configuration)
        {
            //var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            //var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            //var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            //var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True;";
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECT");
            services.AddDbContext<BaseContext>(option => option.UseSqlServer(configuration.GetConnectionString("String2")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<BaseContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IBlogDal, BlogDal>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IHistoryDal, HistoryDal>();
            services.AddScoped<IJobDal, JobDal>();
            services.AddScoped<IPortfolioDal, PortfolioDal>();
            services.AddScoped<ISkillDal, SkillDal>();
            services.AddScoped<ISocialMediaDal, SocialMediaDal>();
            services.AddScoped<IUserAboutDal, UserAboutDal>();
            services.AddScoped<IFileDal, FileDal>();

        }
    }
}
