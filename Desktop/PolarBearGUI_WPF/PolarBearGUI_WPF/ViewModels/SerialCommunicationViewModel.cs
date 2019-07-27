using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public SerialCommunicationViewModel() : base()
        {
            ClearSerialCommunicationCommand = new SerialCommunicationCommand(Clear);

            serialCommunicationList = new List<SerialCommunication>();
            serialCommunicationList.Add(new SerialCommunication("Polar BEAR is Ready", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Polar BEAR is Idle", SerialCommunication.Type.RECIEVE));  
            serialCommunicationList.Add(new SerialCommunication("Sending Path Data", SerialCommunication.Type.SEND));
            serialCommunicationList.Add(new SerialCommunication("Starting Path", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Tilting Arm 5.4 Degrees", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Tilt Completed", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Delaying for 100 Milliseconds", SerialCommunication.Type.RECIEVE));
            serialCommunicationList.Add(new SerialCommunication("Delay Completed", SerialCommunication.Type.RECIEVE));

        }

        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            List<SerialCommunication> communications = new List<SerialCommunication>(serialCommunicationList);
            SerialCommunication serial = new SerialCommunication("This is a test", SerialCommunication.Type.RECIEVE);
            communications.Add(serial);

            if (!EqualsModelLists(serialCommunicationList, communications))
            {
                SerialCommunicationList = communications;
            }
            
        }

        public void Clear()
        {
            SerialCommunicationList = new List<SerialCommunication>();
        }

    }
}
