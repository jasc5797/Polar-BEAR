using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolarBearGUI_WPF
{
    /// <summary>
    /// Interaction logic for SerialMonitorView.xaml
    /// </summary>
    public partial class SerialMonitorView : UserControl
    {
        public List<SerialCommunicationModel> serialCommunicationList { get; set; }
        public SerialMonitorView()
        {
            serialCommunicationList = new List<SerialCommunicationModel>();
            serialCommunicationList.Add(new SerialCommunicationModel("This is a test", SerialCommunicationModel.Type.RECIEVE));

            DataContext = serialCommunicationList;

            InitializeComponent();


        }
    }
}
