using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace PolarBearGUI_WPF.ViewModels
{
    public class COMPortInfoListViewModel : DispatcherViewModel
    {
        private List<COMPortInfoModel> comPortInfoList;

        public List<COMPortInfoModel> COMPortInfos
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

        private COMPortInfoModel comPortInfo;

        public COMPortInfoModel COMPortInfoModel
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

        public COMPortInfoListViewModel() : base()
        {
            comPortInfoList = new List<COMPortInfoModel>();
        }

        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<COMPortInfoModel> newCOMPortInfoList = COMPortInfoModel.GetCOMPortInfoList();
            if (!EqualsModelLists(comPortInfoList, newCOMPortInfoList))
            {
                COMPortInfos = newCOMPortInfoList;
            }
        }
    }
}
