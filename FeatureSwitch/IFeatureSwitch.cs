using ConfigurationProvider.Models;
using FeatureSwitch.Contract;



namespace FeatureSwitch
{
    public interface IFeatureSwitch
    {
        // register features for target app ? path
        public void RegisterFeature(FeatureConfiguration config, string target);

        public void RegisterFeature(FeatureConfiguration config, IFeatureApp instance);

        // Interface for load module to get app path
        public string GetPath();

        public IFeatureApp Get(FeatureConfiguration config);
    }

}
