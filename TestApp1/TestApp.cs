using FeatureSwitch.Feature;

namespace TestApp1
{
    public class TestApp : IFeatureApp
    {
        public object Result
        { 
            get; 
            private set; 
        }   

        public void Execute()
        {
            Result = "TestApp1";
        }
    }
}