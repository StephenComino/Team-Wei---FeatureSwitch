namespace Workshop2022.API.Models.Services
{
    public class FeatureFilter
    {
        public string App { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }
        public string Device { get; set; }

        public string[] CustomFields { get; set; } = new string[5];

    }
}
