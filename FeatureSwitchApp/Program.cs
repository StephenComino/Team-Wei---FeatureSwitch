using ApiClient;
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
            }).Build();

            host.Services.GetRequiredService<IFeatureSwitch>();
            host.Run();


            //host.Services.GetService<IFeatureSwitch>();
        }
    }
}