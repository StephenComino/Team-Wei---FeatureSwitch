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
                services.AddScoped<IFeatureSwitch, FeatureSwitch>();
            }).Build();

            host.Run();

        }
    }
}