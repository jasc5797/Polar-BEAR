using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.JSON
{
    public class JSONStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusTypes { Opened, Ready, Waiting, Stopped };
        public StatusTypes Status { get; set; }
    }
}
