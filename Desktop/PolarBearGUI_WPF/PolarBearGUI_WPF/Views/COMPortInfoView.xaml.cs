using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for COMPortInfoListView.xaml
    /// </summary>
    public partial class COMPortInfoView : UserControl
    {


        public static readonly DependencyProperty SelectedCOMProperty =
            DependencyProperty.Register("SelectedCOMPorperty",
            typeof(COMPortInfo),
            typeof(COMPortInfoView),
            new PropertyMetadata(null));



        public COMPortInfo SelectedCOMItem
        {
            get
            {
               return (COMPortInfo)GetValue(SelectedCOMProperty);
            }

            set
            {
                SetValue(SelectedCOMProperty, value);
                NotifyPropertyChanged("SelectedCOMItem");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public COMPortInfoView()
        {
            InitializeComponent();
            DataContext = new COMPortInfoViewModel();
        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCOMItem = PortComboBox.SelectedItem as COMPortInfo;
            // COMPortInfoModel comPortInfo = (COMPortInfoModel)(PortComboBox.SelectedItem);
            //RunToolBarButton.IsEnabled = comPortInfo != null && comPortInfo.DeviceName.Contains("Arduino");
        }
    }
}
