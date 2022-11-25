using System;
using System.Collections.Generic;
using System.Linq;
using Workshop2022.API.Models.Services;

namespace Workshop2022.API.Services
{
    public class FeatureDataServiceFake : IFeatureDataService
    {
        public IReadOnlyList<FeatureConfigEntity> GetFeatures(Func<FeatureConfigEntity, bool> filter)
        {
            return GetData().Where(filter).ToList(); 
        }

        private IReadOnlyList<FeatureConfigEntity> GetData()
        {
            return new List<FeatureConfigEntity>() 
            {
               new FeatureConfigEntity
               {
                   App = "TestApp01",
                   IpMask = "",
                   UserGroup = "",
                   Device = "",
                   FeatureCode = "Config",
                   Version = "1.1",
                   Enabled = false,
                   CustomFields = null
               },

               new FeatureConfigEntity
               {
                   App = "TestApp01",
                   IpMask = "",
                   UserGroup = "",
                   Device = "",
                   FeatureCode = "Config",
                   Version = "1.2",
                   Enabled = true,
                   CustomFields = null
               },

               new FeatureConfigEntity
               {
                   App = "TestApp01",
                   IpMask = "",
                   UserGroup = "",
                   Device = "",
                   FeatureCode = "Bootstrap",
                   Version = "1.0",
                   Enabled = false,
                   CustomFields = null
               },

               new FeatureConfigEntity
               {
                   App = "TestApp01",
                   IpMask = "",
                   UserGroup = "",
                   Device = "",
                   FeatureCode = "CustMaster",
                   Version = "1.0",
                   Enabled = true,
                   CustomFields = null
               },

               new FeatureConfigEntity
               {
                   App = "TestApp01",
                   IpMask = "192.168.0.0",
                   UserGroup = "",
                   Device = "",
                   FeatureCode = "CustMasterNew",
                   Version = "1.1",
                   Enabled = true,
                   CustomFields = new []
                   {
                       "Sydney"
                   }
               }

            };
        }

    }
}
