
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConfigurationProvider.Contracts;
using FeatureSwitch.Contract;

namespace FeatureSwitch.FeatureHandler
{
    public class FeatureExecutor : IFeatureExecutor
    {
        private IConfigurationProvider _configProvider;
        private IFeatureApp _testApp;

        public FeatureExecutor(IConfigurationProvider configProvider, IFeatureApp testApp)
        {
            _configProvider = configProvider ?? throw new ArgumentNullException(nameof(configProvider));
            _testApp = testApp ?? throw new ArgumentNullException(nameof(testApp));
        }

        public void Run()
        {
            // Load assembly

            _testApp.Execute();

            Console.WriteLine(_testApp.Result);
        }
    }
}
