using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.JSON
{
    public class JSONCommand// : Model
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CommandTypes { Open, Close, Run, Stop, Finished };
        public CommandTypes Command { get; set; }

        public Step Step { get; set; }

        //public Path Path { get; set; }

        public JSONCommand()
        {
           // Path = new Path();
        }

        /*
        public JSONCommand(Path path)
        {
            Command = CommandTypes.Run;
            Path = path;
        }
        */

        /*
        public override bool Equals(Model model)
        {
            if (model is JSONCommand)
            {
                JSONCommand jsonCommand = model as JSONCommand;
                return Command == jsonCommand.Command &&
                    Path == jsonCommand.Path;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCommand = Command.GetHashCode();
            int hashPath = Path.GetHashCode();
            return hashCommand ^ hashPath;
        }*/

       
        public static string Serialize(JSONCommand jsonCommand)
        {
            return jsonCommand.Serialize();
        }

        public static string Serialize(CommandTypes command)
        {
            return Serialize(new JSONCommand() { Command = command });
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }



    }
}
