using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class FilterModel
    {
        public string Application { get; set; }
        public string? IP { get; set; }
        public string UserId { get; set; }
        public string Device { get; set; }
        public Dictionary<string,string> CustomField { get; set; }
    }
}
