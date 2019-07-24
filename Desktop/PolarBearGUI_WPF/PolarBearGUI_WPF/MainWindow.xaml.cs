using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private COMPortInfoModel comComboBoxViewModel;
        private ArduinoSerialPort arduinoSerialPort;

        public MainWindow()
        {
            comComboBoxViewModel = new COMPortInfoModel();
            DataContext = comComboBoxViewModel;

            InitializeComponent();

        }

        private void MenuBarItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Here");
        }

        private void NewFileMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        private void SaveFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }

        private void NewFileToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFileToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveFileToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UndoToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedoToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            COMPortInfo comPortInfo = (COMPortInfo)(PortComboBox.SelectedItem);
            RunToolBarButton.IsEnabled = comPortInfo != null && comPortInfo.DeviceName.Contains("Arduino");
        }

        private void PortComboBox_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void PreviewToolMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsToolMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            COMPortInfo comPortInfo = (COMPortInfo)(PortComboBox.SelectedItem);
            if (comPortInfo != null)
            {
                arduinoSerialPort = new ArduinoSerialPort();
                arduinoSerialPort.PortName = comPortInfo.COMPort;
                arduinoSerialPort.Open();
            }
        }

        private void StopToolBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunToolBarButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (RunToolBarButton.IsEnabled)
            {
                RunToolBarButton.Content = FindResource("RunEnabled");
            }
            else
            {
                RunToolBarButton.Content = FindResource("RunDisabled");
            }
        }

        private void StopToolBarButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (StopToolBarButton.IsEnabled)
            {
                RunToolBarButton.Content = FindResource("StopEnabled");
            }
            else
            {
                RunToolBarButton.Content = FindResource("StopDisabled");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Reading");
            string test = arduinoSerialPort.Read();
            Console.WriteLine(test);
        }
    }
}
