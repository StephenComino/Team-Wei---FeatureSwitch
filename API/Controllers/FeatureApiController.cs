using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workshop2022.API.Models;
using Workshop2022.API.Models.Features;
using Workshop2022.API.Models.Services;
using Workshop2022.API.Services;

namespace Workshop2022.API.Controllers
{
    [ApiController]
    [Route("API")]
    public class FeatureApiController : ControllerBase
    {
        private readonly ILogger<FeatureApiController> _logger;
        private readonly IFeatureDataService _data;


        public FeatureApiController(ILogger<FeatureApiController> logger, IFeatureDataService data)
        {
            _logger = logger;
            _data = data;
        }

        #region -- standard status query --
        [HttpGet]
        [Route("service-status")]
        public string GetServiceStatus()
        {
            return "OK";
        }
        #endregion

        [HttpPost]
        [Route("features")]
        public IActionResult RetrieveFeatures(FeaturesRequest model)
        {
            // -- SAMPLE ONLY - populate filter(s) from request 
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var features = _data.GetFeatures(x => x.App == model.App && x.FeatureCode == model.FeatureCode);

            FeaturesResponse resultEntity;
            // -- add code as needed
            foreach (var feature in features)
            {
                var ipSplit = feature.IpMask.Split(".");
                var remoteIpSplit = ipAddress.ToString().Split(".");
                for (int i = 0; i < ipSplit.Length; i++)
                {
                    if (ipSplit[i] != remoteIpSplit[i] && ipSplit[i] != "0")
                    {
                        continue;
                    } else
                    {
                        resultEntity = new FeaturesResponse()
                        {
                            App = feature.App,
                            UserGroup = feature.UserGroup,
                            CustomFields = feature.CustomFields
                        };
                        return Ok(resultEntity);
                    }
                }
            }
            
            return Ok(new FeaturesResponse());
        }

        
    }
}
