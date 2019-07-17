using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PolarBEAR_GUI
{
    class PortInfo 
    {
        // Keys for use with ManagementObject to get hardware information
        private const string KeyFullName = "Name";
        private const string KeyDeviceName = "Description";
        private const string KeyCOMPort = "DeviceID";

        private const string Query = "SELECT * FROM Win32_SerialPort";

        // Properties
        public string FullName { get; set; } // Device Name (COM port) - Combination of Device Name and COM Port
        public string DeviceName { get; set; } // Device Name Only
        public string COMPort { get; set; } // COM Port Only

        public PortInfo(ManagementObject managementObject)
        {
            FullName = managementObject[KeyFullName].ToString();
            DeviceName = managementObject[KeyDeviceName].ToString();
            COMPort = managementObject[KeyCOMPort].ToString();
        }

        public PortInfo(string fullName, string deviceName, string COMPort)
        {
            FullName = fullName;
            DeviceName = deviceName;
            this.COMPort = COMPort;
        }

        public static List<PortInfo> GetPortInfos()
        {
            List<PortInfo> portInfos = new List<PortInfo>();

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(Query);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                PortInfo portInfo = new PortInfo(managementObject);
                portInfos.Add(portInfo);
            }
            return portInfos;
        }

        public override bool Equals(object obj)
        {
            return obj is PortInfo && Equals(obj as PortInfo);
        }

        public bool Equals(PortInfo portInfo)
        {
            return FullName == portInfo.FullName &&
                DeviceName == portInfo.DeviceName &&
                COMPort == portInfo.COMPort;
        }
    }
}
