using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF
{
    public class COMPortInfoList : Model
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

        private DispatcherTimer dispatcherTimer;


        public COMPortInfoList()
        {
            comPortInfoList = new List<COMPortInfoModel>();
            
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<COMPortInfoModel> newCOMPortInfoList = COMPortInfoModel.GetCOMPortInfoList();
            if (newCOMPortInfoList.Count != COMPortInfos.Count || newCOMPortInfoList.Except(COMPortInfos).Any())
            {
                COMPortInfos = newCOMPortInfoList;
            }
        }
    }
}
