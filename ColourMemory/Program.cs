using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ColourMemory;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = CreateHostBuilder().Build();

        var mainForm = host.Services.GetRequiredService<MainForm>();

        Application.Run(mainForm);
    }

    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.Configure<GameConfig>(context.Configuration);
            services.AddSingleton<MainForm>();
            services.AddSingleton<IGameplayService, GameplayService>();
            services.AddSingleton<IGameplayRepository, GameplayRepository>();
        });
}