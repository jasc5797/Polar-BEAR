using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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
            string test;
            try
            {
                test = ArduinoSerialPort.ReadLine().Trim();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                return;
            }
            if (string.IsNullOrEmpty(test))
            {
                return;
            }

            SerialCommunication serial = new SerialCommunication(test, SerialCommunication.Type.RECIEVE);

            Application.Current.Dispatcher.Invoke(delegate
                {
                    SerialCommunicationList.Add(serial);
                }
            );
            
            /*
            ObservableCollection<SerialCommunication> communications = new ObservableCollection<SerialCommunication>(serialCommunicationList);
            //SerialCommunication serial = new SerialCommunication("This is a test", SerialCommunication.Type.RECIEVE);
            SerialCommunication serial = new SerialCommunication(test, SerialCommunication.Type.RECIEVE);

            communications.Add(serial);


            if (!EqualsModelLists(serialCommunicationList, communications))
            {
                if (communications.Count > 25)
                {
                    int difference = communications.Count - 25;
                    for (int i = 0; i < difference; i++)
                    {
                        communications.RemoveAt(0);
                    }
                }

                SerialCommunicationList = communications;
                
            }*/
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
