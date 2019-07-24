using PolarBearGUI_WPF.ViewModels;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for COMPortInfoListView.xaml
    /// </summary>
    public partial class COMPortInfoListView : UserControl
    {
        public COMPortInfoListView()
        {
            InitializeComponent();
            DataContext = new COMPortInfoListViewModel();
        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // COMPortInfoModel comPortInfo = (COMPortInfoModel)(PortComboBox.SelectedItem);
            //RunToolBarButton.IsEnabled = comPortInfo != null && comPortInfo.DeviceName.Contains("Arduino");
        }
    }
}
