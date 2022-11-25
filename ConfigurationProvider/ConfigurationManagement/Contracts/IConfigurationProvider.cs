using ConfigurationProvider.ConfigurationManagement.Models;

namespace ConfigurationProvider.ConfigurationManagement.Contracts
{
    public interface IConfigurationProvider
    {
        public FeatureConfigEntity LoadConfig();

        public void SaveConfig(FeatureConfigEntity config);
    }
}