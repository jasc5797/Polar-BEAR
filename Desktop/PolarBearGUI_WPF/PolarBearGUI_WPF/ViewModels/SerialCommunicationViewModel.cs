using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public SerialCommunicationViewModel() : base()
        {
            serialCommunicationList = new List<SerialCommunication>();
            SerialCommunication serial = new SerialCommunication("This is a test", SerialCommunication.Type.RECIEVE);
            serialCommunicationList.Add(serial);
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

    }
}
