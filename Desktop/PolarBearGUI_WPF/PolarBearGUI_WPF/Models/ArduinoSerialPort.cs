using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public delegate void ArduinoDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);
        public event ArduinoDataReceivedEventHandler ArduinoDataReceived;

        
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

        public void SetDataReceivedHandler(SerialDataReceivedEventHandler serialDataReceivedEventHandler)
        {
            serialPort.DataReceived += serialDataReceivedEventHandler;
        }


        public void Open()
        {

            serialPort.Open();

        }

        public void Close()
        {
            serialPort.Close();
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
