using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{

    public class SerialCommunicationViewModel
    {
        private List<SerialCommunication> serialCommunicationList;
        public List<SerialCommunication> SerialCommunicationList
        {
            get { return serialCommunicationList; }
        }

        public SerialCommunicationViewModel()
        {
            serialCommunicationList = new List<SerialCommunication>();
            SerialCommunication serial = new SerialCommunication("This is a test", SerialCommunication.Type.RECIEVE);
            serialCommunicationList.Add(serial);

        }
    }
}
