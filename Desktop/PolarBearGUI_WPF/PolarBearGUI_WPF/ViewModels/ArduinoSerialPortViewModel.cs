using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    public class ArduinoSerialPortViewModel : NotifyPropertyChangedObject
    {
        private ArduinoSerialPort arduinoSerialPort;

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
        }

        public ArduinoSerialPortViewModel()
        {
            arduinoSerialPort = new ArduinoSerialPort();
        }
    }
}
