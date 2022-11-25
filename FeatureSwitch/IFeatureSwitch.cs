using System.Collections.Generic;

namespace FeatureSwitch
{
    public interface IFeatureSwitch
    {
        // register features for target app ? path
        public void RegisterFeature(List<Feature> features, string target);

        // Interface for load module to get app path
        public string GetPath();
    }
}
