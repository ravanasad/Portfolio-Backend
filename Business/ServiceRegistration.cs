using Business.Features.Abouts.Rules;
using Business.Features.Auths.Rules;
using Business.Features.Blogs.Rules;
using Business.Features.Contacts.Rules;
using Business.Features.Histories.Rules;
using Business.Features.Jobs.Rules;
using Business.Features.Portfolios.Rules;
using Business.Features.Skills.Rules;
using Business.Features.SocialMedias.Rules;
using Business.Features.UserAbouts.Rules;
using Business.Pipelines;
using Business.Security.JWT;
using Business.Services.FileService;
using Business.Services.Storage;
using Business.Services.Storage.Local;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessRegistration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IJwtService,JwtHelper>();
            services.AddScoped<IStorage,LocalStorage>();
            services.AddScoped<IFileService,FileService>();


            services.AddScoped<AboutBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            services.AddScoped<ContactBusinessRules>();
            services.AddScoped<HistoryBusinessRules>();
            services.AddScoped<JobBusinessRules>();
            services.AddScoped<PortfolioBusinessRules>();
            services.AddScoped<SkillBusinessRules>();
            services.AddScoped<SocialMediaBusinessRules>();
            services.AddScoped<UserAboutBusinessRules>();
            
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
