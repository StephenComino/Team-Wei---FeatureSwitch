using System;

namespace Workshop2022.API.Models.Features
{
    public class FeaturesRequest
    {
        public string App { get; set; }
        public string FeatureCode { get; set; }

        public string Version { get; set; }
    }
}
