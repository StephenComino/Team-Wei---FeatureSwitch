using System;
using System.Collections.Generic;
using System.Linq;
using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;

namespace FeatureSwitch
{
    public class FeatureSwitch : IFeatureSwitch
    {
        private readonly Dictionary<string, List<Feature>> _registerDlls = new Dictionary<string, List<Feature>>();
        private readonly Dictionary<ITickManager, List<Feature>> _registerServices = new Dictionary<ITickManager, List<Feature>>();
        private FeatureConfiguration _config;
        private string _defaultPath = "";
        private readonly IConfigurationProvider _configurationProvider;

        public FeatureSwitch(IConfigurationProvider configurationProvider)
        {
            if (configurationProvider == null)
                throw new Exception("IConfigurationProvider is null");

            _configurationProvider = configurationProvider;
            _config = _configurationProvider.LoadConfig();
        }

        // Register features for app
        public void RegisterFeature(FeatureConfiguration config, string target)
        {
            if (config == null || config.App == null || config.App == "")
                throw new Exception("Null config or app");

            var features = GetFeatures(config);

            _registerDlls.Add(target, features);
        }

        // match features to a target app path
        public string GetPath()
        {
            var features = GetFeatures(_config);
            // use features from GetFeaturesFromConfig() to match the features and return the path
            foreach (var key in _registerDlls.Keys)
            {
                // multiple matches?
                if (_registerDlls[key].Except(features).ToList().Count == 0)
                    return key;
            }
            // todo: return app type whether it is dll, web service or winform
            return _defaultPath;
        }

        // call Interface from storage to get feature set
        public void GetFeaturesFromConfig()
        {
            _config = _configurationProvider.LoadConfig();
        }

        public void RegisterFeature(FeatureConfiguration config, ITickManager instance)
        {
            if (config == null || config.App == null || config.App == "")
                throw new Exception("Null config or app");

            var features = GetFeatures(config);

            _registerServices.Add(instance, features);
        }

        public ITickManager GetInstance()
        {
            var features = GetFeatures(_config);
            foreach (var key in _registerServices.Keys)
            {
                // multiple matches?
                if (_registerServices[key].Except(features).ToList().Count == 0)
                    return key;
            }

            return null; // default instance?
        }

        private List<Feature> GetFeatures(FeatureConfiguration config)
        {
            var features = new List<Feature>();
            // todo: check if every feature is enabled
            features.Add(new Feature { Name = FeatureNames.AppCode, Value = config.App, Version = config.Version, Enabled = config.Enabled, Optional = false });
            features.Add(new Feature { Name = FeatureNames.UserGroup, Value = config.UserGroup, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.IpMask, Value = config.IpMask, Version = "", Enabled = config.Enabled, Optional = true });
            features.Add(new Feature { Name = FeatureNames.Device, Value = config.Device, Version = "", Enabled = config.Enabled, Optional = true });

            foreach (var l in config.CustomFields)
            {
                features.Add(new Feature { Name = FeatureNames.CustomField, Value = l, Version = "", Enabled = config.Enabled, Optional = true });
            }

            return features;
        }
    }

    
}
