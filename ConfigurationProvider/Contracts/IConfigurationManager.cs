using ConfigurationProvider.Models;

namespace ConfigurationProvider.Contracts
{
    public interface IConfigurationManager
    {
        /// <summary>
        /// Saves the current FeatureConfiguration to file.
        /// </summary>
        /// <param name="filePath">File path to save to.</param>
        /// <param name="config">Config to save.</param>
        public void SaveConfigToFile(string filePath, FeatureConfiguration config);


        /// <summary>
        /// Will load the last saved FeatureConfiguration from file.
        /// </summary>
        /// <param name="filePath">File path to load from.</param>
        /// <returns>Last saved FeatureConfiguration or null if file was not found.</returns>
        public FeatureConfiguration? LoadConfigFromFile(string filePath);
    }
}
