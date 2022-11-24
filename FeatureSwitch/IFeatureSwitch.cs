using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureSwitch
{
    public interface IFeatureSwitch
    {
        void Enabled(string feature, string version);
    }
}
