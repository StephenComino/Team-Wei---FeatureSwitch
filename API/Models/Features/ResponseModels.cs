using System;

namespace Workshop2022.API.Models.Features
{
    public class FeaturesResponse
    {
        public string App { get; set; }
        public string UserGroup { get; set; }
        public string IpMask { get; set; }
        public string Device { get; set; }

        public string[] CustomFields { get; set; } = new string[5];

        public string FeatureCode { get; set; }

        public string Version { get; set; }

        public bool Enabled { get; set; }
    }
}
