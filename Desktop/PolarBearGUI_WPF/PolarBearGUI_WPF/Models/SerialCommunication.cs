using System;

namespace PolarBearGUI_WPF.Models
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
                if (string.IsNullOrEmpty(time))
                {
                    return "Unknown";
                }
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
                if (string.IsNullOrEmpty(message))
                {
                    return "Unknown";
                }
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

        public override bool Equals(Model model)
        {
            if (model is SerialCommunication)
            {
                SerialCommunication serialCommunication = model as SerialCommunication;
                return Time == serialCommunication.Time &&
                    Message == serialCommunication.Message &&
                    MessageType == serialCommunication.MessageType;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashTime = Time == null ? 0 : Time.GetHashCode();
            int hashMessage = Message == null ? 0 : Message.GetHashCode();
            int hashMessageType = MessageType == null ? 0 : MessageType.GetHashCode();
            return hashTime ^ hashMessage ^ hashMessageType;
        }
    }
}
