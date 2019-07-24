using System;
using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF
{
    public class SerialCommunication : Model
    {
        public enum Type { SEND, RECIEVE, UNKNOWN };


        private string time;
        private string message;
        private Type messageType;

        public string Time
        {
            get
            {
                return time;
            }
            private set
            {
                time = value;
                NotifyPropertyChanged("Time");
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            private set
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }

        public string MessageType
        {
            get
            {
                return messageType == Type.SEND ? "Sent" : "Recieved";
            }
        }

        public SerialCommunication(string message, Type type)
        {
            Time = DateTime.Now.ToString("T");
            Message = message;
            messageType = type;
        }
    }
}
