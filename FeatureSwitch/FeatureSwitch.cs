using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureSwitch
{
    public class FeatureSwitch : IFeatureSwitch
    {
        private readonly Dictionary<string, List<Feature>> _registerDlls = new Dictionary<string, List<Feature>>();
        private readonly Dictionary<ITickManager, List<Feature>> _registerServices = new Dictionary<ITickManager, List<Feature>>();
        private List<Feature> _features;
        private string _defaultPath = "";

        // Register features for app
        public void RegisterFeature(FeatureConfigEntity config, string target)
        {
            var features = new List<Feature>();
            if (config == null || config.App == null || config.App == "")
                throw new Exception("Null config or app");
            
            // todo: check if every feature is enabled
            features.Add(new Feature { Name=FeatureNames.AppCode, Value=config.App, Version=config.Version, Enabled=config.Enabled, Optional=false});
            features.Add(new Feature { Name = FeatureNames.UserGroup, Value = config.UserGroup, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.IpMask, Value = config.IpMask, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.Device, Value = config.Device, Version = "", Enabled = config.Enabled, Optional = true });

            foreach (var l in config.CustomFields)
            {
                features.Add(new Feature { Name = FeatureNames.CustomField, Value = l, Version = "", Enabled = config.Enabled, Optional = true });
            }

            _registerDlls.Add(target, features);
        }

        // match features to a target app path
        public string GetPath()
        {
            // use features from GetFeaturesFromConfig() to match the features and return the path
            foreach (var key in _registerDlls.Keys)
            {
                // multiple matches?
                if (_registerDlls[key].Except(_features).ToList().Count == 0)
                    return key;
            }
            // todo: return app type whether it is dll, web service or winform
            return _defaultPath;
        }

        // call Interface from storage to get feature set
        public void GetFeaturesFromConfig()
        {
            // set features
        }

        public void RegisterFeature(FeatureConfigEntity config, ITickManager instance)
        {
            var features = new List<Feature>();
            if (config == null || config.App == null || config.App == "")
                throw new Exception("Null config or app");

            // todo: check if every feature is enabled
            features.Add(new Feature { Name = FeatureNames.AppCode, Value = config.App, Version = config.Version, Enabled = config.Enabled, Optional = false });
            features.Add(new Feature { Name = FeatureNames.UserGroup, Value = config.UserGroup, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.IpMask, Value = config.IpMask, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.Device, Value = config.Device, Version = "", Enabled = config.Enabled, Optional = true });

            foreach (var l in config.CustomFields)
            {
                features.Add(new Feature { Name = FeatureNames.CustomField, Value = l, Version = "", Enabled = config.Enabled, Optional = true });
            }

            _registerServices.Add(instance, features);
        }

        public ITickManager GetInstance()
        {
            foreach (var key in _registerServices.Keys)
            {
                // multiple matches?
                if (_registerServices[key].Except(_features).ToList().Count == 0)
                    return key;
            }

            return null; // default instance?
        }
    }

    
}
