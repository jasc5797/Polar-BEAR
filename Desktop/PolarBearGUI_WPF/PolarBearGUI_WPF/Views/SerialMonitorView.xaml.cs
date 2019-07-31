using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels;
using PolarBearGUI_WPF.ViewModels.StepViewModels;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for SerialMonitorView.xaml
    /// </summary>
    public partial class SerialMonitorView : UserControl
    {

        public static readonly DependencyProperty StepViewModelsProperty =
            DependencyProperty.Register("StepList",
            typeof(List<StepViewModel>),
            typeof(SerialMonitorView),
            new FrameworkPropertyMetadata(new List<StepViewModel>()));

        public List<StepViewModel> StepViewModels
        {
            get
            {
                return (List<StepViewModel>)GetValue(StepViewModelsProperty);
            }
            set
            {
                SetValue(StepViewModelsProperty, value);
            }
        }
        /*

        public static readonly DependencyProperty ArduinoSerialPortProperty =
            DependencyProperty.Register("ArduinoSerialPortProperty",
            typeof(ArduinoSerialPort),
            typeof(SerialCommunicationViewModel),
            new FrameworkPropertyMetadata(new ArduinoSerialPort()));

        public ArduinoSerialPort ArduinoSerialPort
        {
            get
            {
                return (ArduinoSerialPort)GetValue(ArduinoSerialPortProperty);
            }
            set
            {
                SetValue(ArduinoSerialPortProperty, value);
            }
        }*/

        public SerialMonitorView()
        {
            InitializeComponent();
            DataContext = new SerialCommunicationViewModel();
            ((INotifyCollectionChanged)(SerialListView.Items)).CollectionChanged += SerialListView_CollectionChanged;


        }

        private void AutoScroll()
        {
            bool isAutoScrollChecked = AutoScrollCheckBox.IsChecked.HasValue && AutoScrollCheckBox.IsChecked.Value;
            if (isAutoScrollChecked)
            {
                if (SerialListView != null && !SerialListView.Items.IsEmpty)
                {
                    var last = SerialListView.Items[SerialListView.Items.Count - 1];
                    SerialListView.ScrollIntoView(last);
                }
            }
        }

        private void SerialListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                AutoScroll();
            }
        }

        private void AutoScrollCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            AutoScroll();
        }
    }
}
