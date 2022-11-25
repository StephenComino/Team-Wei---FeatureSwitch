using ConfigurationProvider.Models;

namespace ConfigurationProvider.Contracts
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Will load the last saved FeatureConfiguration from file.
        /// </summary>
        /// <returns>Last saved FeatureConfiguration or null if file was not found.</returns>
        public FeatureConfiguration LoadConfig();

        /// <summary>
        /// Saves the current FeatureConfiguration to file.
        /// </summary>
        /// <param name="config">FeatureConfiguration to save.</param>
        public void SaveConfig(FeatureConfiguration config);
    }
}