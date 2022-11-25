using FeatureSwitch.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using ConfigurationProvider;
using ConfigurationProvider.Contracts;
using ConfigurationProvider.Models;

namespace FeatureSwitch
{
    public class FeatureSwitch : IFeatureSwitch
    {
        private readonly Dictionary<string, List<Feature>> _registerDlls = new Dictionary<string, List<Feature>>();
        private readonly Dictionary<IFeatureApp, List<Feature>> _registerServices = new Dictionary<IFeatureApp, List<Feature>>();
        private List<Feature> _features = new List<Feature>();
        private string _defaultPath = "";


        public FeatureSwitch()
        {

        }

        // Register features for app
        public void RegisterFeature(FeatureConfiguration config, string target)
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


        public void RegisterFeature(FeatureConfiguration config, IFeatureApp instance)
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
        public IFeatureApp Get(FeatureConfiguration config)
        {
            return _registerServices.Keys.ElementAt(0);
        }

    }

    
}
