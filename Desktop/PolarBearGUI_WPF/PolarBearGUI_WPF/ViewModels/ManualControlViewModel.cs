using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    public class ManualControlViewModel : CustomViewModel
    {
        public RelayCommand TiltCWCommand { get; private set; }
        public RelayCommand TiltCCWCommand { get; private set; }
        public RelayCommand TiltHomeCommand { get; private set; }

        public RelayCommand RotationCWCommand { get; private set; }
        public RelayCommand RotationCCWCommand { get; private set; }
        public RelayCommand RotationHomeCommand { get; private set; }

        public RelayCommand ExtensionExtendCommand { get; private set; }
        public RelayCommand ExtensionRetractCommand { get; private set; }
        public RelayCommand ExtensionHomeCommand { get; private set; }

        public RelayCommand EndEffectorTiltCWCommand { get; private set; }
        public RelayCommand EndEffectorTiltCCWCommand { get; private set; }

        public RelayCommand EndEffectorRotationCWCommand { get; private set; }
        public RelayCommand EndEffectorRotationCCWCommand { get; private set; }

        public ArduinoSerialPort ArduinoSerialPort { get; set; }

        public ManualControlViewModel()
        {
            TiltCWCommand = new RelayCommand(TiltCW);
            TiltCCWCommand = new RelayCommand(TiltCCW);
            TiltHomeCommand = new RelayCommand(TiltHome);
            RotationCWCommand = new RelayCommand(RotationCW);
            RotationCCWCommand = new RelayCommand(RotationCCW);
            RotationHomeCommand = new RelayCommand(RotationHome);
            ExtensionExtendCommand = new RelayCommand(ExtensionExtend);
            ExtensionRetractCommand = new RelayCommand(ExtensionRetract);
            ExtensionHomeCommand = new RelayCommand(ExtensionHome);
            EndEffectorTiltCWCommand = new RelayCommand(EndEffectorTiltCW);
            EndEffectorTiltCCWCommand = new RelayCommand(EndEffectorTiltCCW);
            EndEffectorRotationCWCommand = new RelayCommand(EndEffectorRotationCW);
            EndEffectorRotationCCWCommand = new RelayCommand(EndEffectorRotationCCW);
        }

        private void EndEffectorRotationCCW()
        {
            EndEffector endEffector = new EndEffector(0, -10);
            ArduinoSerialPort.RunManualControl(endEffector);
        }

        private void EndEffectorRotationCW()
        {
            EndEffector endEffector = new EndEffector(0, 10);
            ArduinoSerialPort.RunManualControl(endEffector);
        }

        private void EndEffectorTiltCCW()
        {
            EndEffector endEffector = new EndEffector(-10, 0);
            ArduinoSerialPort.RunManualControl(endEffector);
        }

        private void EndEffectorTiltCW()
        {
            EndEffector endEffector = new EndEffector(10, 0);
            ArduinoSerialPort.RunManualControl(endEffector);
        }

        private void ExtensionHome()
        {
            Home home = new Home(Home.ComponentType.Extension);
            ArduinoSerialPort.RunManualControl(home);
        }

        private void ExtensionRetract()
        {
            Extension extension = new Extension(-5);
            ArduinoSerialPort.RunManualControl(extension);
        }

        private void ExtensionExtend()
        {
            Extension extension = new Extension(5);
            ArduinoSerialPort.RunManualControl(extension);
        }

        private void RotationHome()
        {
            Home home = new Home(Home.ComponentType.Rotation);
            ArduinoSerialPort.RunManualControl(home);
        }

        private void RotationCCW()
        {
            Rotation rotation = new Rotation(-25);
            ArduinoSerialPort.RunManualControl(rotation);
        }

        private void RotationCW()
        {
            Rotation rotation = new Rotation(25);
            ArduinoSerialPort.RunManualControl(rotation);
        }

        private void TiltHome()
        {
            Home home = new Home(Home.ComponentType.Tilt);
            ArduinoSerialPort.RunManualControl(home);
        }

        private void TiltCCW()
        {
            Tilt tilt = new Tilt(-5);
            ArduinoSerialPort.RunManualControl(tilt);
        }

        private void TiltCW()
        {
            Tilt tilt = new Tilt(5);
            ArduinoSerialPort.RunManualControl(tilt);
        }
    }
}
