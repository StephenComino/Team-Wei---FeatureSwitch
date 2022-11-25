using ApiClient;
using ConfigurationProvider.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FeatureSwitch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
            {
                services.AddScoped<IClient, Client>();
                services.AddSingleton<IFeatureSwitch, FeatureSwitch>();
                services.AddScoped<IConfigurationProvider, ConfigurationProvider.ConfigurationProvider>();


                services.AddScoped<IFeatureSwitch, FeatureSwitch>(s =>
                {
                    FeatureSwitch fs = new FeatureSwitch();

                    // fs.Register("TestApp", "v1", new TestApp1.TestApp());

                    return fs;
                });

                services.AddScoped<IFeatureApp>(s =>
                {
                    var fs = s.GetService<IFeatureSwitch>() ?? throw new ArgumentNullException("IFeatureSwitch");
                    var configProvider = s.GetService<IConfigurationProvider>() ?? throw new ArgumentNullException("IConfigurationProvider");

                    var config = configProvider.LoadConfig();

                    return fs.Get();
                });

                services.AddScoped<IFeatureExecutor, FeatureExecutor>();
            }).Build();

            var executor = host.Services.GetRequiredService<IFeatureExecutor>();
            executor.Run();

            host.Run();
        }
    }
}