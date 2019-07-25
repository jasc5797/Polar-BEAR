﻿using System;
using System.Collections.Generic;
using System.Management;

namespace PolarBearGUI_WPF.Models
{
    public class COMPortInfoModel : Model
    {
        // Keys for use with ManagementObject to get hardware information
        private const string KeyFullName = "Name";
        private const string KeyDeviceName = "Description";
        private const string KeyCOMPort = "DeviceID";

        private const string Query = "SELECT * FROM Win32_SerialPort";

        // Properties
        private string fullName;
        private string deviceName;
        private string comPort;

        // Device Name (COM port) - Combination of Device Name and COM Port
        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                fullName = value;
                NotifyPropertyChanged("FullName");
            }
        }
        // Device Name Only
        public string DeviceName
        {
            get
            {
                return deviceName;
            }
            private set
            {
                deviceName = value;
                NotifyPropertyChanged("DeviceName");
            }
        }

        // COM Port Only
        public string COMPort
        {
            get
            {
                return comPort;
            }
            private set
            {
                comPort = value; NotifyPropertyChanged("COMPort");
            }
        }

        public COMPortInfoModel(ManagementObject managementObject)
        {
            FullName = managementObject[KeyFullName].ToString();
            DeviceName = managementObject[KeyDeviceName].ToString();
            COMPort = managementObject[KeyCOMPort].ToString();
        }

        public COMPortInfoModel(string fullName, string deviceName, string COMPort)
        {
            FullName = fullName;
            DeviceName = deviceName;
            this.COMPort = COMPort;
        }

        public static List<COMPortInfoModel> GetCOMPortInfoList()
        {
            List<COMPortInfoModel> comPortInfoList = new List<COMPortInfoModel>();

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(Query);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                COMPortInfoModel portInfo = new COMPortInfoModel(managementObject);
                comPortInfoList.Add(portInfo);
            }
            return comPortInfoList;
        }


        public override int GetHashCode()
        {
            int hashFullName = FullName == null ? 0 : FullName.GetHashCode();
            int hashDeviceName = DeviceName == null ? 0 : DeviceName.GetHashCode();
            int hashCOMPort = COMPort == null ? 0 : COMPort.GetHashCode();
            return hashFullName ^ hashDeviceName ^ hashCOMPort;
        }

        public override bool Equals(Model model)
        {
            if (model is COMPortInfoModel)
            {
                COMPortInfoModel comPortInfoModel = model as COMPortInfoModel;
                return FullName == comPortInfoModel.FullName &&
                    DeviceName == comPortInfoModel.DeviceName &&
                    COMPort == comPortInfoModel.COMPort;
            }
            return false;
        }
    }

    /*
    class COMPortInfoComparer : IEqualityComparer<COMPortInfoModel>
    {
        public bool Equals(COMPortInfoModel x, COMPortInfoModel y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Equals(y);
        }

        public int GetHashCode(COMPortInfoModel comPortInfo)
        {
            if (Object.ReferenceEquals(comPortInfo, null))
                return 0;
            return comPortInfo.GetHashCode();
        }
    }
    */
}