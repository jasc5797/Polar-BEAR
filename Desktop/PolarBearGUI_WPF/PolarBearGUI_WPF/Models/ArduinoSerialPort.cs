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

        private ObservableCollection<SerialCommunication> serialCommunications;

        
        public ArduinoSerialPort(ObservableCollection<SerialCommunication> serialCommunications)
        {
            this.serialCommunications = serialCommunications;
            Initialize();
        }

        private void Initialize()
        {

            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Handshake = Handshake.None;

            serialPort.DataReceived += SerialPort_DataReceived;

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialCommunications.Add(new SerialCommunication(serialPort.ReadExisting(), SerialCommunication.Type.RECIEVE));
        }

        public void Open()
        {

            serialPort.Open();

        }

        public void Close()
        {
            serialPort.Close();
        }
        
        public string Read()
        {
            return serialPort.ReadExisting();
        }

        public void Send(string message)
        {
            serialPort.WriteLine(message);
        }

    }
}
