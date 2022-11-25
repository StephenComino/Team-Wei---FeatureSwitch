using System.Collections.Generic;
using ConfigurationProvider;
using ConfigurationProvider.Models;

namespace FeatureSwitch
{
    public interface IFeatureSwitch
    {
        // register features for target app ? path
        public void RegisterFeature(FeatureConfiguration config, string target);

        public void RegisterFeature(FeatureConfiguration config, ITickManager instance);

        // Interface for load module to get app path
        public string GetPath();

        public ITickManager GetInstance();
    }

    public interface ITickManager
    {

    }
}
