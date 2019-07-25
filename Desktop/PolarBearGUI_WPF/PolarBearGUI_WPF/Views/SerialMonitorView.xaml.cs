using PolarBearGUI_WPF.ViewModels;
using System.Collections.Specialized;
using System.Linq;
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
