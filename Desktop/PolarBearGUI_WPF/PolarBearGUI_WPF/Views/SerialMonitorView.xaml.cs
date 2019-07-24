using PolarBearGUI_WPF.ViewModels;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for SerialMonitorView.xaml
    /// </summary>
    public partial class SerialMonitorView : UserControl
    {
        public SerialMonitorView()
        {
            InitializeComponent();
            DataContext = new SerialCommunicationViewModel();
        }
    }
}
