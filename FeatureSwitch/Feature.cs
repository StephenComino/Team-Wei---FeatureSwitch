namespace FeatureSwitch
{
    public struct Feature
    {
        public FeatureNames Name;
        public string Value;
        public string Version;
        public bool Enabled;
        public bool Optional;
    }

    public enum FeatureNames
    {
        AppCode,
        UserGroup,
        IpMask,
        Device,
        FeatureCode,
        CustomField,
    }
}
