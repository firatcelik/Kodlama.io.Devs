using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Features.UserSocialMediaAddresses.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Devs.Application.Services.AuthService;

namespace Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddScoped<IValidator<CreateLanguageCommand>, CreateLanguageCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<UserSocialMediaAddressBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
