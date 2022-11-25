using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureSwitch.Feature
{
    public interface IFeatureApp
    {
        void Execute();

        object Result { get; }
    }
}
