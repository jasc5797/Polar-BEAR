using Microsoft.Win32;
using PolarBearGUI_WPF.JSON;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels;
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
using Path = PolarBearGUI_WPF.Models.Path;

namespace PolarBearGUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArduinoSerialPort ArduinoSerialPort { get; set; }

        public SerialPort SerialPort { get; set; }

        public MainWindow()
        {

            InitializeComponent();
            SerialPort = new SerialPort();
            ArduinoSerialPort = new ArduinoSerialPort();

            COMPortInfoListView.PortComboBox.SelectionChanged += PortComboBox_SelectionChanged;

            SerialCommunicationViewModel serialCommunicationViewModel = ArduinoSerialPortView.DataContext as SerialCommunicationViewModel;
            serialCommunicationViewModel.ArduinoSerialPort = ArduinoSerialPort;
        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            RunToolBarButton.IsEnabled = comboBox.SelectedItem != null;
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
            openFileDialog.Title = "Load Path";
            openFileDialog.Filter = "Polar BEAR File (.bear)| *.bear";
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Path path = (Path)Model.DeserializeFromFile(openFileDialog.FileName);
                (PathEditor.DataContext as PathEditorViewModel).StepList = path.Steps;
            }
        }

        private void SaveFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Path";
            saveFileDialog.Filter = "Polar BEAR File (.bear)| *.bear";
            bool? result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                List<Step> steps = (PathEditor.DataContext as PathEditorViewModel).StepList;
                Path path = new Path(steps);
               // string json = path.Serialize();
                path.SerializeToFile(saveFileDialog.FileName);
            }
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

        private void PreviewToolMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsToolMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            
            COMPortInfoModel comPortInfo = COMPortInfoListView.SelectedCOMItem;
            if (comPortInfo != null)
            {
                ArduinoSerialPort.Open(comPortInfo.COMPort);

                StopToolBarButton.IsEnabled = true;
                RunToolBarButton.IsEnabled = false;

                List<Step> steps = (PathEditor.DataContext as PathEditorViewModel).StepList;
                JSONCommand jsonCommand = new JSONCommand(new Path(steps));
                ArduinoSerialPort.Send(jsonCommand);
            }
        }

        private void StopToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArduinoSerialPort.IsOpen)
            {
                ArduinoSerialPort.Close();
            }
            StopToolBarButton.IsEnabled = false;
            RunToolBarButton.IsEnabled = true;
        }

        private void RunToolBarButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (RunToolBarButton.IsEnabled)
            {
                //RunToolBarButton.Content = FindResource("RunEnabled");
            }
            else
            {
               // RunToolBarButton.Content = FindResource("RunDisabled");
            }
        }

        private void StopToolBarButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (StopToolBarButton.IsEnabled)
            {
                //RunToolBarButton.Content = FindResource("StopEnabled");
            }
            else
            {
                //RunToolBarButton.Content = FindResource("StopDisabled");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Reading");
           // string test = arduinoSerialPort.Read();
            //Console.WriteLine(test);
        }

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            var test = COMPortInfoListView.SelectedCOMItem;
        }
    }
}
