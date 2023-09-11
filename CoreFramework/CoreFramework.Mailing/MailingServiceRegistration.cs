
using CoreFramework.Mailing;
using CoreFramework.Mailing.MailKitImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFramework.Mailing;

public static class MailingServiceRegistration
{
    public static IServiceCollection AddMailingServices(this IServiceCollection services)
    {
        services.AddScoped<IMailService, MailKitMailService>();
        return services;
    }
}