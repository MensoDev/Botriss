using EchoBotriss.EchoBot.Bots;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;

namespace EchoBotriss.EchoBot.IoC;

public static class BotrissServiceConfig
{
    public static void AddBotrissServices(this IServiceCollection services)
    {
        // Create the Bot Framework Authentication to be used with the Bot Adapter.
        services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
        // Create the Bot Adapter with error handling enabled.
        services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
        // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
        services.AddTransient<IBot, TrissEchoBot>();
    }
}