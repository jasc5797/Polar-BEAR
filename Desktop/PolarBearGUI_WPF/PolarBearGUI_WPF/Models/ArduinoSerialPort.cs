using Newtonsoft.Json;
using PolarBearGUI_WPF.JSON;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels;
using System;
using System.IO.Ports;
using System.Windows;

namespace PolarBearGUI_WPF.Models
{
    public class ArduinoSerialPort : NotifyPropertyChangedObject
    {
        private SerialPort serialPort;

        public string PortName
        {
            get
            {
                return serialPort.PortName;
            }
            set
            {
                serialPort.PortName = value;
                NotifyPropertyChanged("PortName");
            }
        }

        public bool IsOpen { get { return serialPort.IsOpen; } }

        public enum StatusTypes
        {
            Disconnected,
            Connected,
            Run,
            Error
        }

        private StatusTypes status;

        public StatusTypes Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        public Path Path { get; set; }


        public SerialDataReceivedEventHandler SerialDataReceivedEventHandler { get; set; }

        public SerialCommunicationViewModel SerialCommunicationViewModel { get; set; }

        public MainWindow MainWindow { get; set; }

        /*
        public delegate void ArduinoDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);
        public event ArduinoDataReceivedEventHandler ArduinoDataReceived;
        */

        public ArduinoSerialPort()
        {
            Initialize();
        }

        private void Initialize()
        {
            status = StatusTypes.Disconnected;

            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Handshake = Handshake.None;
            serialPort.NewLine = ";";
        }

        /*
        public void SetDataReceivedHandler(SerialDataReceivedEventHandler serialDataReceivedEventHandler)
        {
            serialPort.DataReceived += serialDataReceivedEventHandler;
        }
        */

        public void Open(string comPortName)
        {
            serialPort.PortName = comPortName;
            serialPort.DataReceived += SerialDataReceivedEventHandler;
            Open();
        }

        public void Open()
        {
            if (IsOpen)
            {
                serialPort.DataReceived += SerialDataReceivedEventHandler;
                Close();
            }
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not open COM port: " + ex.ToString());
                string message = "Unable to open port: " + PortName + Environment.NewLine + "Try reconnecting the Arduino";
                string caption = "Unknown Connection Error";
                MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (IsOpen)
            {
                //Status = StatusTypes.Connected;
                JSONCommand jsonCommand = new JSONCommand { Command = JSONCommand.CommandTypes.Open };
                Send(jsonCommand);
            }
        }

        public void Close()
        {
            if (IsOpen)
            {
                Path.Clear();
                JSONCommand jsonCommmand = new JSONCommand()
                {
                    Command = JSONCommand.CommandTypes.Close
                };
                Send(jsonCommmand);
                serialPort.DataReceived -= SerialDataReceivedEventHandler;
                serialPort.Close();
            }
            Status = StatusTypes.Disconnected;
        }

        public void Run()
        {
            if (IsOpen)
            {
                Status = StatusTypes.Run;
            }
        }

        public string ReadLine()
        {
            return serialPort.ReadLine();
        }

        public void Send(string message)
        {
            serialPort.WriteLine(message);
            SerialCommunicationViewModel.AddSentMessage(message);
        }

        public void HandleMessage(string message)
        {
            try
            {
                HandleMessage(JsonConvert.DeserializeObject<JSONStatus>(message));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to deserialize status: " + ex.ToString());
            }
        }

        public void HandleMessage(JSONStatus jsonStatus)
        {
            switch(jsonStatus.Status)
            {
                case JSONStatus.StatusTypes.Opened:
                    Status = StatusTypes.Connected;
                    break;
                case JSONStatus.StatusTypes.Waiting:
                    SendNextStep();
                    break;
                case JSONStatus.StatusTypes.Ready:
                    MainWindow.RunCompleted();
                    break;
                case JSONStatus.StatusTypes.Stopped:

                    break;
            }
        }

        public void Send(JSONCommand jsonCommand)
        {
            Send(jsonCommand.Serialize());
        }

        public void SendNextStep()
        {
            JSONCommand jsonCommand = new JSONCommand();
            if (Path.IsEmpty)
            {
                jsonCommand.Command = JSONCommand.CommandTypes.Finished;
            }
            else
            {
                jsonCommand.Command = JSONCommand.CommandTypes.Run;
                jsonCommand.Step = Path.GetNextStep();
            }
            Send(jsonCommand);   
        }

        public void Stop()
        {
            Path.Clear();
            JSONCommand jsonCommand = new JSONCommand()
            {
                Command = JSONCommand.CommandTypes.Stop
            };
            Send(jsonCommand);
        }

    }
}
