using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureSwitch.Contract
{
    public interface IFeatureApp
    {
        void Execute();

        object Result { get; }
    }
}
