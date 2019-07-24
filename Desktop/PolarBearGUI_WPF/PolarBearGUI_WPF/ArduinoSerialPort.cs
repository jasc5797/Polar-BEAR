using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF
{
    class ArduinoSerialPort
    {
        private SerialPort serialPort;

        public string PortName { get { return serialPort.PortName; } set { serialPort.PortName = value; } }

        public bool IsOpen { get { return serialPort.IsOpen; } }
        
        public ArduinoSerialPort()
        {
            Initialize();
        }

        private void Initialize()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Handshake = Handshake.None;
        }

        public void Open()
        {

            serialPort.Open();

        }
        
        public string Read()
        {
            return serialPort.ReadExisting();
        }

    }
}
