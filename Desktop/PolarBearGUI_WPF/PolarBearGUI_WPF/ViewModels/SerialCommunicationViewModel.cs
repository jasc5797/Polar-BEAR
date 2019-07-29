using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace PolarBearGUI_WPF.ViewModels
{

    public class SerialCommunicationViewModel : DispatcherViewModel
    {

        private List<SerialCommunication> serialCommunicationList;
        public List<SerialCommunication> SerialCommunicationList
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

        public SerialCommunicationCommand ClearSerialCommunicationCommand { get; private set; }

        private SerialPort serialPort;

        public SerialCommunicationViewModel() : base()
        {
            ClearSerialCommunicationCommand = new SerialCommunicationCommand(Clear);

            serialCommunicationList = new List<SerialCommunication>();
            /*
            serialCommunicationList.Add(new SerialCommunication("Polar BEAR is Ready", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Polar BEAR is Idle", SerialCommunication.Type.RECIEVE));  
            serialCommunicationList.Add(new SerialCommunication("Sending Path Data", SerialCommunication.Type.SEND));
            serialCommunicationList.Add(new SerialCommunication("Starting Path", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Tilting Arm 5.4 Degrees", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Tilt Completed", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Delaying for 100 Milliseconds", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Delay Completed", SerialCommunication.Type.RECIEVE));
            */

        }

        public SerialCommunicationViewModel(SerialPort serialPort) : this()
        {
            this.serialPort = serialPort;
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.NewLine = ";";
            serialPort.WriteLine("o");
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }
            string test;
            try
            {
                test = serialPort.ReadLine().Replace("\r", "");
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

            List<SerialCommunication> communications = new List<SerialCommunication>(serialCommunicationList);
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
                
            }
        }

        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            /*
            if (serialPort == null || !serialPort.IsOpen)
            {
                return;
            }
            string test = serialPort.ReadLine().Replace("\r", "");
            if (string.IsNullOrEmpty(test))
            {
                return;
            }

            List<SerialCommunication> communications = new List<SerialCommunication>(serialCommunicationList);
            //SerialCommunication serial = new SerialCommunication("This is a test", SerialCommunication.Type.RECIEVE);
            SerialCommunication serial = new SerialCommunication(test, SerialCommunication.Type.RECIEVE);

            communications.Add(serial);
            

            if (!EqualsModelLists(serialCommunicationList, communications))
            {
                SerialCommunicationList = communications;
            }
            */
        }

        public void Clear()
        {
            SerialCommunicationList = new List<SerialCommunication>();
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

    }
}
