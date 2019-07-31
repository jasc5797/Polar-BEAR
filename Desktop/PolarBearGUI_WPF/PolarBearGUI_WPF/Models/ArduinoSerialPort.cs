using PolarBearGUI_WPF.JSONCommands;
using PolarBearGUI_WPF.Utilities;
using System.IO.Ports;

namespace PolarBearGUI_WPF.Models
{
    public class ArduinoSerialPort : NotifyPropertyChangedObject
    {
        private SerialPort serialPort;

        public string PortName
        {
            get
            {
                return serialPort.PortName;
            }
            set
            {
                serialPort.PortName = value;
                NotifyPropertyChanged("PortName");
            }
        }

        public bool IsOpen { get { return serialPort.IsOpen; } }


        public SerialDataReceivedEventHandler SerialDataReceivedEventHandler
        {
            get;
            set;
        }

        /*
        public delegate void ArduinoDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);
        public event ArduinoDataReceivedEventHandler ArduinoDataReceived;
        */

        public ArduinoSerialPort()
        {
            Initialize();
        }

        private void Initialize()
        {

            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Handshake = Handshake.None;
            serialPort.NewLine = ";";


        }

        /*
        public void SetDataReceivedHandler(SerialDataReceivedEventHandler serialDataReceivedEventHandler)
        {
            serialPort.DataReceived += serialDataReceivedEventHandler;
        }
        */

        public void Open(string comPortName)
        {
            serialPort.PortName = comPortName;
            serialPort.DataReceived += SerialDataReceivedEventHandler;
            Open();
        }

        public void Open()
        {
            if (IsOpen)
            {
                serialPort.DataReceived += SerialDataReceivedEventHandler;
                Close();
            }
            serialPort.Open();
            string openCommand = JSONCommand.Serialize(JSONCommand.CommandTypes.Run);
            serialPort.WriteLine(openCommand);

        }

        public void Close()
        {
            if (IsOpen)
            {
                serialPort.WriteLine("c");
                serialPort.DataReceived -= SerialDataReceivedEventHandler;
                serialPort.Close();
            }
        }
        
        public string ReadLine()
        {
            return serialPort.ReadLine();
        }

        public void Send(string message)
        {
            serialPort.WriteLine(message);
        }

    }
}
