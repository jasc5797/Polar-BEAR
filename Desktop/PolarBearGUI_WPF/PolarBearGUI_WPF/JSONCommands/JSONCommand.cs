using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.JSONCommands
{
    public class JSONCommand
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CommandTypes { Open, Close, Run, Stop };
        public CommandTypes Command { get; set; }

        public static string Serialize(JSONCommand jsonCommand)
        {
            return JsonConvert.SerializeObject(jsonCommand);
        }

        public static string Serialize(CommandTypes command)
        {
            return Serialize(new JSONCommand() { Command = command });
        }

       
    }
}
