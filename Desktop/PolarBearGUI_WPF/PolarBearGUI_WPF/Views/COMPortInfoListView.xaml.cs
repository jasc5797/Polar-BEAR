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
    public partial class COMPortInfoListView : UserControl
    {


        public static readonly DependencyProperty SelectedCOMProperty =
            DependencyProperty.Register("SelectedCOMPorperty",
            typeof(COMPortInfoModel),
            typeof(COMPortInfoListView),
            new PropertyMetadata(null));



        public COMPortInfoModel SelectedCOMItem
        {
            get
            {
               return (COMPortInfoModel)GetValue(SelectedCOMProperty);
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

        public COMPortInfoListView()
        {
            InitializeComponent();
            DataContext = new COMPortInfoListViewModel();
        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCOMItem = PortComboBox.SelectedItem as COMPortInfoModel;
            // COMPortInfoModel comPortInfo = (COMPortInfoModel)(PortComboBox.SelectedItem);
            //RunToolBarButton.IsEnabled = comPortInfo != null && comPortInfo.DeviceName.Contains("Arduino");
        }
    }
}
