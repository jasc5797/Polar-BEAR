using PolarBearGUI_WPF.JSON;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Windows;

namespace PolarBearGUI_WPF.ViewModels
{

    public class SerialCommunicationViewModel : CustomViewModel
    {

        private ObservableCollection<SerialCommunication> serialCommunicationList;
        public ObservableCollection<SerialCommunication> SerialCommunicationList
        {
            get
            {
                return serialCommunicationList;
            }
            set
            {
                serialCommunicationList = value;
                NotifyPropertyChanged("SerialCommunicationList");
            }
        }

        

        public RelayCommand ClearSerialCommunicationCommand { get; private set; }

        private ArduinoSerialPort arduinoSerialPort;
        public ArduinoSerialPort ArduinoSerialPort
        {
            get
            {
                return arduinoSerialPort;
            }
            set
            {
                arduinoSerialPort = value;
                arduinoSerialPort.SerialDataReceivedEventHandler = SerialPort_DataReceived;
                arduinoSerialPort.SerialCommunicationViewModel = this;
            }
        }

        public SerialCommunicationViewModel()
        {
            ClearSerialCommunicationCommand = new RelayCommand(Clear);

            serialCommunicationList = new ObservableCollection<SerialCommunication>();

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!ArduinoSerialPort.IsOpen)
            {
                return;
            }
            string message;
            try
            {
                message = ArduinoSerialPort.ReadLine().Trim();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                return;
            }
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            SerialCommunication serial = new SerialCommunication(message, SerialCommunication.Type.RECIEVE);

            Application.Current.Dispatcher.Invoke(delegate
                {
                    SerialCommunicationList.Add(serial);
                    arduinoSerialPort.HandleMessage(message);
                }
            );
        }

        public void AddSentMessage(JSONCommand jsonCommand)
        {
            AddSentMessage(jsonCommand.Serialize());
        }
        
        public void AddSentMessage(string message)
        {
            SerialCommunication serial = new SerialCommunication(message, SerialCommunication.Type.SEND);
            SerialCommunicationList.Add(serial);
        }

        public void Clear()
        {
            SerialCommunicationList = new ObservableCollection<SerialCommunication>();
        }

        // If this is used the clear button does not automatically enable again even after data is added to SerialCommunicationList
        public bool CanClear()
        {
            return SerialCommunicationList.Count > 0;
        }

        public bool IsOpen()
        {
            return ArduinoSerialPort.IsOpen;
        }

    }
}
