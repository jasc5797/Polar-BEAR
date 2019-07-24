using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PolarBearGUI_WPF
{
    public class COMPortInfo : Models.Model
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

        public COMPortInfo(ManagementObject managementObject)
        {
            FullName = managementObject[KeyFullName].ToString();
            DeviceName = managementObject[KeyDeviceName].ToString();
            COMPort = managementObject[KeyCOMPort].ToString();
        }

        public COMPortInfo(string fullName, string deviceName, string COMPort)
        {
            FullName = fullName;
            DeviceName = deviceName;
            this.COMPort = COMPort;
        }

        public static List<COMPortInfo> GetCOMPortInfoList()
        {
            List<COMPortInfo> comPortInfoList = new List<COMPortInfo>();

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(Query);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                COMPortInfo portInfo = new COMPortInfo(managementObject);
                comPortInfoList.Add(portInfo);
            }
            return comPortInfoList;
        }

       
        public override bool Equals(object obj)
        {
            return obj is COMPortInfo && Equals(obj as COMPortInfo);
        }

        public bool Equals(COMPortInfo comPortInfo)
        {
            return FullName == comPortInfo.FullName &&
                DeviceName == comPortInfo.DeviceName &&
                COMPort == comPortInfo.COMPort;
        }

        public override int GetHashCode()
        {
            int hashFullName = FullName == null ? 0 : FullName.GetHashCode();
            int hashDeviceName = DeviceName == null ? 0 : DeviceName.GetHashCode();
            int hashCOMPort = COMPort == null ? 0 : COMPort.GetHashCode();
            return hashFullName ^ hashDeviceName ^ hashCOMPort;
        }
    }

    class COMPortInfoComparer : IEqualityComparer<COMPortInfo>
    {
        public bool Equals(COMPortInfo x, COMPortInfo y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Equals(y);
        }

        public int GetHashCode(COMPortInfo comPortInfo)
        {
            if (Object.ReferenceEquals(comPortInfo, null))
                return 0;
            return comPortInfo.GetHashCode();
        }
    }
}
