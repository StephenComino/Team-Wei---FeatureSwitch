using System;
using System.Collections.Generic;
using System.Linq;
using Workshop2022.API.Models.Services;

namespace Workshop2022.API.Services
{
    public interface IFeatureDataService
    {
        IReadOnlyList<FeatureConfigEntity> GetFeatures(Func<FeatureConfigEntity, bool> filter);
    }
}
