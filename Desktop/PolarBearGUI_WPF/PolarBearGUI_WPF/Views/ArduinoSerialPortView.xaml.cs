using PolarBearGUI_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for ArduinoSerialPortView.xaml
    /// </summary>
    public partial class ArduinoSerialPortView : UserControl
    {

        public ArduinoSerialPortView()
        {
            InitializeComponent();
            //DataContext = new ArduinoSerialPortViewModel();
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
