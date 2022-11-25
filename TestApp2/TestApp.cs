using FeatureSwitch.Contract;

namespace TestApp2
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
            Result = "TestApp2";
        }
    }
}