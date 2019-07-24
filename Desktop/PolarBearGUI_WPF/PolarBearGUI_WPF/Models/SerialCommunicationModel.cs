using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PolarBearGUI_WPF
{
    public class SerialCommunicationModel : Models.Model
    {
        public enum Type { SEND, RECIEVE };

        private Type type;

        public string Time { get; private set; }
        public string Message { get; set; }

        public string MessageType { get { return type == Type.SEND ? "Sent" : "Recieved"; } }

        public SerialCommunicationModel(string message, Type type)
        {
            Time = DateTime.Now.ToString("T");
            Message = message;
            this.type = type;
        }
    }
}
