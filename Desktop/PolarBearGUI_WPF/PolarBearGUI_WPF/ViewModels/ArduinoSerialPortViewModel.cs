using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    public class ArduinoSerialPortViewModel : NotifyPropertyChangedObject
    {
        private ArduinoSerialPort arduinoSerialPort;

        /*
        public ArduinoSerialPort ArduinoSerialPort
        {
            get {
                return arduinoSerialPort;
            }
            set
            {
                arduinoSerialPort = value;
                NotifyPropertyChanged("ArduinoSerialPort");
            }
        }*/

        private ObservableCollection<SerialCommunication> serialCommunications;

        public ObservableCollection<SerialCommunication> SerialCommunications
        {
            get
            {
                return serialCommunications;
            }
            set
            {
                serialCommunications = value;
                NotifyPropertyChanged("SerialCommunications");
            }
        }

        public ArduinoSerialPortViewModel(string COMPort)
        {
            serialCommunications = new ObservableCollection<SerialCommunication>();
            arduinoSerialPort = new ArduinoSerialPort(serialCommunications);
            arduinoSerialPort.PortName = COMPort;
            arduinoSerialPort.Open();
        }
    }
}
