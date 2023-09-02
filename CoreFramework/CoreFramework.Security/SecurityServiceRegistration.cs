using CoreFramework.Security.EmailAuthenticator;
using CoreFramework.Security.JWT;
using CoreFramework.Security.OtpAuthenticator;
using CoreFramework.Security.OtpAuthenticator.OtpNet;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFramework.Application;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        return services;
    }
}