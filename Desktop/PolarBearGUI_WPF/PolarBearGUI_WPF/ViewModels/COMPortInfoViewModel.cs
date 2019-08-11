using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;

namespace PolarBearGUI_WPF.ViewModels
{
    public class COMPortInfoViewModel : DispatcherViewModel
    {
        private List<COMPortInfo> comPortInfoList;

        public List<COMPortInfo> COMPortInfoList
        {
            get
            {
                return comPortInfoList;
            }
            private set
            {
                comPortInfoList = value;
                NotifyPropertyChanged("COMPortInfos");
            }
        }

        private COMPortInfo comPortInfo;

        public COMPortInfo COMPortInfoModel
        {
            get
            {
                return comPortInfo;
            }
            set
            {
                comPortInfo = value;
                NotifyPropertyChanged("COMPortInfoModel");
            }
        }

        public COMPortInfoViewModel() : base()
        {
            comPortInfoList = new List<COMPortInfo>();
        }

        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<COMPortInfo> newCOMPortInfoList = COMPortInfo.GetCOMPortInfoList();
            if (!EqualsModelLists(comPortInfoList, newCOMPortInfoList))
            {
                COMPortInfoList = newCOMPortInfoList;
            }
        }
    }
}
