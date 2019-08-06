using Microsoft.Win32;
using PolarBearGUI_WPF.JSON;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PolarBearGUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArduinoSerialPort ArduinoSerialPort { get; set; }

        public MainWindow()
        {


            InitializeComponent();

            ArduinoSerialPort = new ArduinoSerialPort();
            ArduinoSerialPort.MainWindow = this;

            COMPortInfoListView.PortComboBox.SelectionChanged += PortComboBox_SelectionChanged;

            SerialCommunicationViewModel serialCommunicationViewModel = ArduinoSerialPortView.DataContext as SerialCommunicationViewModel;
            serialCommunicationViewModel.ArduinoSerialPort = ArduinoSerialPort;

            ManualControlViewModel manualControlViewModel = ManualControlView.DataContext as ManualControlViewModel;
            manualControlViewModel.ArduinoSerialPort = ArduinoSerialPort;

        }

        private void PortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ConnectToolBarButton.IsEnabled = comboBox.SelectedItem != null && !ArduinoSerialPort.IsOpen;
        }

        private void MenuBarItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Here");
        }

        private void NewFileToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            (PathEditor.DataContext as PathEditorViewModel).StepList = new List<Step>();
        }

        private void OpenFileToolBarButton_Click(object sender, RoutedEventArgs e)
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

        private void SaveFileToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Path";
            saveFileDialog.Filter = "Polar BEAR File (.bear)| *.bear";
            bool? result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                List<Step> steps = (PathEditor.DataContext as PathEditorViewModel).StepList;
                Path path = new Path(steps);
                path.SerializeToFile(saveFileDialog.FileName);
            }
        }


        private void RunToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            
            COMPortInfoModel comPortInfo = COMPortInfoListView.SelectedCOMItem;
            if (comPortInfo != null)
            {
                //ArduinoSerialPort.Open(comPortInfo.COMPort);
              
                ArduinoSerialPort.Path = new Path((PathEditor.DataContext as PathEditorViewModel).StepList);
                ArduinoSerialPort.SendNextStep();


                StopToolBarButton.IsEnabled = true;
                RunToolBarButton.IsEnabled = false;

                ManualControlView.IsEnabled = false;

                //List<Step> steps = (PathEditor.DataContext as PathEditorViewModel).StepList;
                //JSONCommand jsonCommand = new JSONCommand(new Path(steps));
                //ArduinoSerialPort.Send(jsonCommand);
            }
        }

        private void StopToolBarButton_Click(object sender, RoutedEventArgs e)
        {      
            if (ArduinoSerialPort.IsOpen)
            {
                ArduinoSerialPort.Stop();
            }
            StopToolBarButton.IsEnabled = false;
            RunToolBarButton.IsEnabled = true;

            ManualControlView.IsEnabled = true;
            
        }


        public void RunCompleted()
        {    
            StopToolBarButton.IsEnabled = false;
            RunToolBarButton.IsEnabled = true;

            ManualControlView.IsEnabled = true;
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


        private void ConnectToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            COMPortInfoModel comPortInfo = COMPortInfoListView.SelectedCOMItem;
            if (comPortInfo != null)
            {
                ArduinoSerialPort.Open(comPortInfo.COMPort);

                if (ArduinoSerialPort.IsOpen)
                {
                    ConnectToolBarButton.IsEnabled = false;
                    ConnectToolBarButton.Visibility = Visibility.Collapsed;
                    RunToolBarButton.IsEnabled = true;
                    DisconnectToolBarButton.Visibility = Visibility.Visible;
                    DisconnectToolBarButton.IsEnabled = true;

                    ManualControlView.IsEnabled = true;
                }
            }
        }

        private void DisconnectToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            ArduinoSerialPort.Close();
            ConnectToolBarButton.IsEnabled = true;
            ConnectToolBarButton.Visibility = Visibility.Visible;
            RunToolBarButton.IsEnabled = false;
            StopToolBarButton.IsEnabled = false;
            DisconnectToolBarButton.IsEnabled = false;
            DisconnectToolBarButton.Visibility = Visibility.Collapsed;

            ManualControlView.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ArduinoSerialPort.IsOpen)
            {
                ArduinoSerialPort.Close();
            }
        }
    }
}
