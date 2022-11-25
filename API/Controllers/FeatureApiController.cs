using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public IActionResult RetrieveFeatures(object model)
        {

            var requestModel = JsonConvert.DeserializeObject<FeaturesRequest>(model.ToString());
            // -- SAMPLE ONLY - populate filter(s) from request 
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var features = _data.GetFeatures(x => x.App == requestModel.App && x.FeatureCode == requestModel.FeatureCode);

            if (features.Count > 0)
            {
                FeaturesResponse resultEntity = new FeaturesResponse()
                {
                    App = features[0].App,
                    UserGroup = features[0].UserGroup,
                    CustomFields = features[0].CustomFields
                };
                return Ok(JsonConvert.SerializeObject(resultEntity));
            }
        
            /// Check IP
            
            var data = JsonConvert.SerializeObject(new FeaturesResponse());
            return BadRequest(data);
        }

        
    }
}
